using System;

/* This class represents each node in a self-organizing map neural network*/
class Neuron
{

    //represents location of neuron in web
    public int xCoord, yCoord, zCoord;

    //this array holds the weights for the neuron
    public double[] weights;

    /*constructor - creates a new neuron at specified location in web with specified amount of weights*/
    public Neuron(int x, int y, int z, int dataDimension)
    {
        xCoord = x;
        yCoord = y;
        zCoord = z;

        weights = new double[dataDimension];
    }

    /*function returns the minkowski distance between an input vector and this neuron*/
    public double GetMinkowskiDistance(double[] values, double power, double[] inputWeights)
    {
        double result = 0;

        for (int weight = 0; weight < weights.Length; weight++)
            result += Math.Pow(Math.Abs(values[weight]*inputWeights[weight] - weights[weight]), power);

        result = Math.Pow(result, 1 / power);

        return result;
    }

}
