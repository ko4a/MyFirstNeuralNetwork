using System;
using System.Collections.Generic;

namespace MyFirstNeuralNetwork
{
    public class Neuron
    {
        public List<double> Weights { get;  }
        public NeuronType NeuronType{ get; }
        public double Output { get; private  set; }

        public Neuron(int inputCount, NeuronType type= NeuronType.Normal)
        {
            NeuronType = type;
            Weights = new List<double>();

            for (int i = 0; i < inputCount; i++)
                Weights.Add(1);
        }

        public double FeedForward(List<double> inputs)
        {
            if (inputs.Count != Weights.Count) throw new ArgumentException("inputs count should be equal with weights count");

            var sum = 0.0;
            for (int i = 0; i < inputs.Count; i++)
                sum += inputs[i] * Weights[i];

            Output = Sigmoid(sum);
            return Output;
        }

        


        private double Sigmoid(double x) => 1.0 / (1.0 + Math.Pow(Math.E, -x));

        public override string ToString()
        {
            return Output.ToString();
        }
    }
}
