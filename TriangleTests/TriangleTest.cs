using System;
using Triangles.Controllers;
using Xunit;
using FluentAssertions;
using Triangles.Models;
using System.Collections.Generic;

namespace TriangleTests
{
    public class TriangleTest
    {
        private const string TRIANGLE_INFO_TEMPLATE = "Triangle:{0}({1}, {2}, {3}){0}Reduced:{0}({4:F2}, {5:F2}, {6:F2}){0}{0}Area = {7:F2}{0}Perimeter = {8}";
        private readonly TriangleController controller;

        private string _generateOutput(double side1, double side2, double side3, double perimeter, double area)
        {
            return string.Format(TRIANGLE_INFO_TEMPLATE
                , Environment.NewLine
                , side1
                , side2
                , side3
                , side1 / perimeter
                , side2 / perimeter
                , side3 / perimeter
                , area
                , perimeter
                );
        }

        public TriangleTest()
        {
            controller = new TriangleController();
        }

        [Theory]
        [InlineData(3, 4, 5, 12, 6)]
        [InlineData(5, 6, 7, 18, 14.70)]
        public void Info_WithCorrectOrderedSides_ReturnsStringWithData(double side1, double side2, double side3, double perimeter, double area)
        {
            controller.Info(new Triangle(side1, side2, side3))
                .Should().BeEquivalentTo(_generateOutput(side1, side2, side3, perimeter, area));
        }

        [Theory]
        [InlineData(4, 3, 5, 12, 6)]
        [InlineData(6, 5, 7, 18, 14.70)]
        public void Info_WithCorrectUnOrdered1and2Sides_ReturnsStringWithData(double side1, double side2, double side3, double perimeter, double area)
        {

            controller.Info(new Triangle(side1, side2, side3))
                .Should().BeEquivalentTo(_generateOutput(side2, side1, side3, perimeter, area));
        }

        [Theory]
        [InlineData(5, 4, 3, 12, 6)]
        [InlineData(7, 6, 5, 18, 14.70)]
        public void Info_WithCorrectReverseOrderedSides_ReturnsStringWithData(double side1, double side2, double side3, double perimeter, double area)
        {

            controller.Info(new Triangle(side1, side2, side3))
                .Should().BeEquivalentTo(_generateOutput(side3, side2, side1, perimeter, area));
        }

        [Theory]
        [InlineData(5, 4, 3, 6)]
        [InlineData(7, 6, 5, 14.69690)]
        public void Area_WithCorrectSides_ReturnsArea(double side1, double side2, double side3, double area)
        {
            string.Format("{0:F4}", area).Should().BeEquivalentTo(
                string.Format("{0:F4}", controller.Area(new Triangle(side1, side2, side3))));
        }

        [Theory]
        [InlineData(5, 4, 3, 12)]
        [InlineData(7, 6, 5, 18)]
        public void Perimeter_WitCorrectSides_ReturnsPerimeter(double side1, double side2, double side3, double perimeter)
        {
            controller.Perimeter(new Triangle(side1, side2, side3)).ToString().Should().BeEquivalentTo(perimeter.ToString());
        }

        [Theory]
        [InlineData(3, 4, 5, true)]
        [InlineData(4, 5, 6.403124, true)]
        [InlineData(5, 6, 7, false)]
        public void IsRightAngled_WithRCorrectSides_ReturnsWhetherRightAngled(double side1, double side2, double side3, bool isRightAngled)
        {
            controller.IsRightAngled(new Triangle(side1, side2, side3)).Should().Be(isRightAngled);
        }

        [Theory]
        [InlineData(3, 3, 3, true)]
        [InlineData(6, 6, 6.00002, true)]
        [InlineData(6.00006, 6.00011, 6.00016, false)]
        [InlineData(6.00005, 6, 6.00004, true)]
        public void IsEquilateral_WithRCorrectSides_ReturnsWhetherEquilatera(double side1, double side2, double side3, bool isRightAngled)
        {
            controller.IsEquilateral(new Triangle(side1, side2, side3)).Should().Be(isRightAngled);
        }

        [Theory]
        [InlineData(3, 3, 6, true)]
        [InlineData(6, 5, 6.00002, true)]
        [InlineData(6.00006, 8, 6.00016, false)]
        [InlineData(9, 6, 7, false)]
        [InlineData(9, 6, 6, true)]
        public void IsIsosceles_WithRCorrectSides_ReturnsWhetherIsosceles(double side1, double side2, double side3, bool isRightAngled)
        {
            controller.IsIsosceles(new Triangle(side1, side2, side3)).Should().Be(isRightAngled);
        }

        [Theory]
        [InlineData(3, 3, 6, 3, 3, 6)]
        [InlineData(3.5, 3, 6, 3, 3.5, 6.00002)]
        public void AreCongruent_WithAlmostEqualSides_ReturnsTrue(double side1, double side2, double side3, double side4, double side5, double side6)
        {
            controller.AreCongruent(new Triangle(side1, side2, side3), new Triangle(side4, side5, side6)).Should().BeTrue();
        }

        [Theory]
        [InlineData(3, 3, 6, 3, 4, 7)]
        [InlineData(3, 3, 6, 3, 3, 6.0003)]
        public void AreCongruent_WithNotEqualSides_ReturnsFalse(double side1, double side2, double side3, double side4, double side5, double side6)
        {
             controller.AreCongruent(new Triangle(side1, side2, side3), new Triangle(side4, side5, side6)).Should().BeFalse();
        }

        [Theory]
        [InlineData(3, 3, 6, 4, 4, 8)]
        [InlineData(10, 20, 15, 30, 20, 40)]
        [InlineData(3, 3, 6, 4, 4, 8.00002)]
        public void AreSimilar_WithAlmostProportionalSides_ReturnsTrue(double side1, double side2, double side3, double side4, double side5, double side6)
        {
            controller.AreSimilar(new Triangle(side1, side2, side3), new Triangle(side4, side5, side6)).Should().BeTrue();
        }
        
        [Theory]
        [InlineData(3, 3, 6, 4, 4, 9)]
        [InlineData(10, 20, 15, 15, 12, 20)]
        [InlineData(3, 3, 6, 4, 4, 8.004)]
        public void AreSimilar_WithAlmostProportionalSides_ReturnsFalse(double side1, double side2, double side3, double side4, double side5, double side6)
        {
            controller.AreSimilar(new Triangle(side1, side2, side3), new Triangle(side4, side5, side6)).Should().BeFalse();


        }
        
        [Fact]
        public void InfoGreatestPerimeter_CorrectTriangles_ReturnsStringWithData()
        {
            controller.InfoGreatestPerimeter(TrianglesArray)
                .Should().BeEquivalentTo(_generateOutput(5, 6, 7, 18, 14.70));

        }
        
        [Fact]
        public void InfoGreatestArea_CorrectTriangles_ReturnsStringWithData()
        {
            controller.InfoGreatestArea(TrianglesArray)
                .Should().BeEquivalentTo(_generateOutput(5.95, 6, 6, 17.95, 15.5));
        }
        
        public static Triangle[] TrianglesArray =
        new Triangle[]
        {
            new Triangle(4, 3, 5),
            new Triangle(6, 5, 7),
            new Triangle(6, 6, 5.95),
            new Triangle(3, 2.5, 3.5),
        };
        
        [Fact]
        public void NumbersPairwiseNotSimilar_CorrectTriangles_ReturnsPairsNotSimilar()
        {
            controller.NumbersPairwiseNotSimilar(TrianglesArray)
                .Should().BeEquivalentTo("(1, 2)" + Environment.NewLine
                                                  + "(1, 3)" + Environment.NewLine
                                                  + "(1, 4)" + Environment.NewLine
                                                  + "(2, 3)" + Environment.NewLine
                                                  + "(3, 4)");
        }
    }
}
