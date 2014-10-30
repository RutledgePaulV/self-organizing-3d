using System;
using System.Collections.Generic;

class NeuronWeb
{
    //random generator
    private Random gen;

    //represents the dimensions of the neuron web
    public int width, height, depth;

    //3-Dimensional neuron web (reveals more information about clusters)
    public Neuron[, ,] web;

    private double[] weightInputs;

    public struct NeuronIndex
    {
       public  int X, Y, Z;
        public NeuronIndex (int x, int y, int z)
    	{
        	X=x;
        	Y=y;
        	Z = z;
    	}
    }

    //global parameters used in updating weights
    private double initialLearningRate, initialNeighborhoodRadius;

    /*constructor - builds a 3 dimensional neuron web with the specified dimensions and initializes neurons with appropriate dimensioned weights*/
    public NeuronWeb(int x, int y, int z, int dataDimension, double learningRate)
    {
        //setting the dimensions of the web
        width = x;
        height = y;
        depth = z;

        weightInputs = new double[4]{1,1,1,1};

        //seeding the random generator
        gen = new Random(DateTime.Now.Millisecond);

        //default learning rate
        initialLearningRate = learningRate;

        //default neighborhood radius
        initialNeighborhoodRadius = Math.Pow(x*y*z, 1 / (double)dataDimension) / 2.0;

        //allocating array of neurons
        web = new Neuron[x, y, z];

        //initializing each neuron in web
        for (int row = 0; row < width; row++)
            for (int col = 0; col < height; col++)
                for (int dep = 0; dep < depth; dep++)
                    web[row, col, dep] = new Neuron(row, col, dep, dataDimension); 
    }

    /*this method trains the weights for each neuron in the web using the data provided*/
    public void Train(List<double[]> training, int epochs, bool linear)
    {
        //training for each epoch
        for (int epoch = 0; epoch < epochs; epoch++)
        {
            //if user desires to train network an equal amount of times through each sample
            if (linear)
            {
                //flips through linearly unless the epochs is not divisible by amount of training samples
                if (epoch < epochs - training.Count || training.Count%training.Count == 0)
                {
                    UpdateWeights(training[epoch%training.Count], epoch / (float)epochs);
                }
                else
                {
                    linear = false;
                }
            }
            //if user wants to randomly flip through training set
            else
            {
                //picks a random input sample to train from
                UpdateWeights(training[gen.Next(training.Count)], epoch / (float)epochs);
            }
        }
    }

    public Dictionary<NeuronIndex, List<double[]>> ClassifyData(List<double[]> input)
    {
        Dictionary<NeuronIndex, List<double[]>> set = new Dictionary<NeuronIndex,List<double[]>>();
        Neuron n;
        NeuronIndex index;
        foreach (double[] vector in input)
        {
            n=this.GetWinner(vector, 2);
          index = new NeuronIndex(n.xCoord,n.yCoord,n.zCoord);
            if(set.ContainsKey(index))
            {
                set[index].Add(vector);
            }
            else
            {
                List<double[]> list = new List<double[]>();
                list.Add(vector);
                set.Add(index,list);
            }
        }

        return set;
    }

    /* this method randomy initializes the weights for each neuron in web*/
    public void InitializeWeights(double minimum, double maximum)
    {
        var delta = (maximum - minimum);

        for (int row = 0; row < width; row++)
            for (int col = 0; col < height; col++)
                for (int dep = 0; dep < depth; dep++)
                    for (int weight = 0; weight < web[row, col, dep].weights.Length; weight++)
                        web[row, col, dep].weights[weight] = gen.NextDouble() * delta + minimum;
    }

    /* this is where the learning takes place - an input vector is input and all weights are adjusted*/
    private void UpdateWeights(double[] input, double fractionComplete)
    {
        //variables determine effect and radius of area that is effected by the input sample
        double distanceOnGrid, effect;
        double learningRate = initialLearningRate * Math.Pow(Math.E, -fractionComplete);
        double neighborhoodSize = initialNeighborhoodRadius * Math.Pow(Math.E, -fractionComplete);

        //getting the neuron that is the best match to the input sample
        Neuron winner = GetWinner(input, 2);

        //looping through all neurons
        for (int row = 0; row < width; row++)
            for (int col = 0; col < height; col++)
                for (int dep = 0; dep < depth; dep++)
                {
                    //calculating distance between this neuron and the winning neuron
                    distanceOnGrid = (winner.xCoord - row) * (winner.xCoord - row);
                    distanceOnGrid+= (winner.yCoord - col) * (winner.yCoord - col);
                    distanceOnGrid+=(winner.zCoord - dep) * (winner.zCoord - dep);
                    
                    //calculating how much effect the input vector should have on current neuron
                    effect = Math.Pow(Math.E, -distanceOnGrid / (2 * neighborhoodSize * neighborhoodSize));

                    //updating all this neuron's weights accordingly
                    for (int weight = 0; weight < web[row, col, dep].weights.Length; weight++)
                            web[row, col, dep].weights[weight] += effect * learningRate * (input[weight] - web[row, col, dep].weights[weight]);
                }
    }

    /*this function returns the neuron that best matches the input vector*/
    private Neuron GetWinner(double[] input, double minkowskiPower)
    {
        //variables to hold distance each neuron is from the input, and a minimum to keep track of the closest neuron found yet
        double dist, minimum = Double.MaxValue;

        //creating a list to hold all possible winners
        List<Neuron> winners = new List<Neuron>();
    
        //looping through all neurons
        for (int row = 0; row < width; row++)
            for (int col = 0; col < height; col++)
                for (int dep = 0; dep < depth; dep++)
                {
                    //calculating minkowski distance between input and this neuron
                    dist = web[row, col, dep].GetMinkowskiDistance(input, minkowskiPower,weightInputs);

                    //if this neuron is closer than a previously found
                    if (dist < minimum)
                    {
                        winners.Clear();
                        winners.Add(web[row, col, dep]);
                        minimum = dist;
                    }
                     //otherwise if it is the same as the closest yet found - add it as well
                    else if (dist == minimum)
                        winners.Add(web[row, col, dep]);
        }

        //pick from the closest neurons
        return winners[gen.Next(winners.Count)];
    }

    public void SetInitialLearningRate(double rate)
    {
        initialLearningRate = rate;
    }

    public void SetInitialNeighborhoodRadius(double radius)
    {
        initialNeighborhoodRadius = radius;
    }

    public void WriteToCSV(string filename)
    {

        int octant= 0;
        System.IO.StreamWriter writer = new System.IO.StreamWriter(filename+ ".csv");
        writer.Write("Octant");

        for (int weight = 0; weight < web[0, 0, 0].weights.Length; weight++)
            writer.Write(",Weight " + (weight + 1));

        writer.WriteLine();

        for (int row = 0; row < width; row++)
            for (int col = 0; col < height; col++)
               for (int dep = 0; dep < depth; dep++)
                {                    
                    writer.Write(octant);
                    for (int weight = 0; weight < web[row, col, dep].weights.Length; weight++)
                        writer.Write("," + web[row, col, dep].weights[weight]);
                    writer.WriteLine();
                }

        writer.Close();
    
    }
}
