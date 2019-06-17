using System;
using System.Collections.Generic;
using System.Linq;

namespace MyFirstNeuralNetwork
{
    public class NeuralNetwork
    {
        public List<Layer> Layers { get;}
        public Topology Topology { get; }

        public NeuralNetwork(Topology Topology)
        {
            this.Topology = Topology;
            Layers = new List<Layer>();
            CreateInputLayer();
            CreateHiddenLayers();
            CreateOutputLayer();
        }



        public double FeedForward(List<double> inputSignals)
        {
            if (inputSignals.Count != Topology.InputCount) throw new TypeAccessException("input signals should be equal with Topology input count");
            for (int i = 0; i < inputSignals.Count; i++)
            {
                var signal = new List<double>() { inputSignals[i] };
                var neuron = Layers[0].Neurons[i];
                neuron.FeedForward(signal);
            }
            


        }

        private void CreateOutputLayer()
        {
            var outputNeurons = new List<Neuron>();
            var lastLayer = Layers.Last();
            for (int i = 0; i < Topology.OutputCount; i++)
            {
                var neuron = new Neuron(lastLayer.Count, NeuronType.Output);
                outputNeurons.Add(neuron);
            }
            var layer = new Layer(outputNeurons, NeuronType.Output);
            Layers.Add(layer);
        }

        private void CreateHiddenLayers()
        {
            for (int k = 0; k < Topology.HiddenLayers.Count; k++)
            {


                var HiddenNeurons = new List<Neuron>();
                var lastLayer = Layers.Last();
                for (int i = 0; i < Topology.HiddenLayers[k]; i++)
                {
                    var neuron = new Neuron(lastLayer.Count);
                    HiddenNeurons.Add(neuron);
                }
                var layer = new Layer(HiddenNeurons);
                Layers.Add(layer);
            }
        }

        private void CreateInputLayer()
        {
            var inputNeurons = new List<Neuron>();

            for (int i = 0; i < Topology.InputCount; i++)
            {
                var neuron = new Neuron(1, NeuronType.Input);
                inputNeurons.Add(neuron);
            }
            var layer = new Layer(inputNeurons, NeuronType.Input);
            Layers.Add(layer);
        }
    }
}
