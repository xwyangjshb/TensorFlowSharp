﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TensorFlowSharp.Tests.CSharp
{
    public static class TestUtils
    {
        public static void MatrixEqual(double[,] expected, double[,] actual, int precision)
        {
            for (int i = 0; i < expected.GetLength(0); i++)
                for (int j = 0; j < expected.GetLength(1); j++)
                    Assert.Equal(expected[i, j], actual[i, j], precision: precision);
        }

        public static void MatrixEqual(Array expected, Array actual, int precision)
        {
            Assert.Equal(expected.Length, actual.Length);
            Assert.Equal(expected.Rank, actual.Rank);
            Assert.Equal(expected.GetType(), actual.GetType());

            var ei = expected.GetEnumerator();
            var ai = actual.GetEnumerator();

            var expectedType = expected.GetType().GetElementType();

            if (expectedType == typeof(double))
            {
                while (ei.MoveNext() && ai.MoveNext())
                    Assert.Equal((double)ei.Current, (double)ai.Current, precision: 8);
            }
            else if (expectedType == typeof(float))
            {
                while (ei.MoveNext() && ai.MoveNext())
                    Assert.Equal((float)ei.Current, (float)ai.Current, precision: 8);
            }
            else
            {
                while (ei.MoveNext() && ai.MoveNext())
                    Assert.True(Object.Equals(ei.Current, ai.Current));
            }
        }
    }
}
