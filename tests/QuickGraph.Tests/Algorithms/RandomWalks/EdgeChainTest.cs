﻿using System;
using System.Linq;
using System.Collections.Generic;
using QuickGraph.Algorithms.Observers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Pex.Framework;
using QuickGraph.Serialization;

namespace QuickGraph.Algorithms.RandomWalks
{
    [TestClass]
    public class EdgeChainTest
    {
        [TestMethod]
        public void GenerateAll()
        {
            foreach (var g in TestGraphFactory.GetAdjacencyGraphs())
                this.Generate(g);
        }

        [PexMethod]
        public void Generate<TVertex, TEdge>(IVertexListGraph<TVertex, TEdge> g)
            where TEdge : IEdge<TVertex>
        {

            foreach (var v in g.Vertices)
            {
                var walker = new RandomWalkAlgorithm<TVertex, TEdge>(g);
                var vis = new EdgeRecorderObserver<TVertex, TEdge>();
                using(vis.Attach(walker))
                    walker.Generate(v);
            }
        }
    }
}
