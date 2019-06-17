using System;
using System.Collections.Generic;

namespace MyFirstNeuralNetwork
{
    public class Layer
    {
        public List<Neuron> Neurons { get; }
        public int Count => Neurons?.Count ?? 0;

        public Layer(IEnumerable<Neuron> neurons, NeuronType type = NeuronType.Normal)
        {
            if (AreAllNeuronsHaveSameType(neurons, type)) throw new TypeAccessException("all neurons should have same type");
            Neurons = new List<Neuron>(neurons);
        }

        private bool AreAllNeuronsHaveSameType(IEnumerable<Neuron> neurons,NeuronType type)
        {
            foreach(var neuron in neurons)
                if (neuron.NeuronType != type) return false;
            return true;
        }
    }
}
