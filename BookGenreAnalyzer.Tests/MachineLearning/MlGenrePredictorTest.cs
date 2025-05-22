// using System;
// using System.Collections.Generic;
// using System.IO;
// using System.Linq;
// using BookGenreAnalyzer.MachineLearning;
// using BookGenreAnalyzer.Tests.TestData;
// using Microsoft.ML;
// using Newtonsoft.Json;
// using Xunit;
//
// namespace BookGenreAnalyzer.Tests.MachineLearning;
//
// public class MlGenrePredictorTest
// {
//     private readonly MlGenrePredictor _predictor;
//
//     public MlGenrePredictorTest()
//     {
//         var mlContext = new MLContext();
//         _predictor = new MlGenrePredictor(mlContext);
//     }
//
//     public static IEnumerable<object[]> LoadTestData()
//     {
//         var json = File.ReadAllText("TestData/genre-test-data.json"); 
//         var testCases = JsonConvert.DeserializeObject<List<GenreTestCase>>(json);
//         return testCases.Select(tc => new object[] { tc.Text, tc.Expected });
//     }
//
//     [Fact]
//     public void All_GenrePredictions_Should_Match_Expected()
//     {
//         var filePath = @"C:\Users\kamil\RiderProjects\BookGenreAnalyzer\BookGenreAnalyzer.Tests\TestData\genre-test-data.json";
//         var json = File.ReadAllText(filePath);
//         var testCases = JsonConvert.DeserializeObject<List<GenreTestCase>>(json);
//
//         foreach (var testCase in testCases)
//         {
//             var predicted = _predictor.PredictGenre(testCase.Text);
//
//             Assert.True(
//                 predicted.Equals(testCase.Expected, StringComparison.OrdinalIgnoreCase),
//                 $"Expected: {testCase.Expected}, but got: {predicted}.\nText: \"{testCase.Text}\""
//             );
//         }
//     }
// }
//     
