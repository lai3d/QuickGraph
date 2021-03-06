// <copyright file="FibonacciHeapFactory.cs" company="MSIT">Copyright © MSIT 2007</copyright>

using System;
using Microsoft.Pex.Framework;
using QuickGraph.Collections;

namespace QuickGraph.Collections
{
    public static partial class FibonacciHeapFactory
    {
        [PexFactoryMethod(typeof(FibonacciHeap<int, int>))]
        public static FibonacciHeap<int, int> Create()
        {
            FibonacciHeap<int, int> fibonacciHeap
               = new FibonacciHeap<int, int>();
            return fibonacciHeap;
        }
    }
}
