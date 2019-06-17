using System;
using System.Collections.Generic;

namespace MyFirstNeuralNetwork
{
    public class Topology
    {
        public int InputCount { get; }//количество входов в нейронную сеть(в первый слой)
        public int OutputCount { get; } //выходных слоёв

        public List<int> HiddenLayers { get; } // количество нейронов на скрытом слое

        public Topology(int inputCount, int OutputCount, params int [] layers)
        {
            InputCount = inputCount;
            this.OutputCount = OutputCount;
            HiddenLayers = new List<int>();
            HiddenLayers.AddRange(layers);
        }
    }
}
