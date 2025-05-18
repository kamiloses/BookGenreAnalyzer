using System;
using System.IO;
using System.IO.Compression;
using BookGenreAnalyzer.MachineLearning;
using Microsoft.ML;
using Xunit;

namespace BookGenreAnalyzer.Tests.MachineLearning
{
    public class MlTrainerTest : IDisposable
    {
        private readonly MlTrainer _mlTrainer;
        private readonly MLContext _mlContext;
        private readonly MlDataLoader _mlDataLoader;
        private string path = @"C:\Users\kamil\RiderProjects\BookGenreAnalyzer\BookGenreAnalyzer\wwwroot\ZIPFiles\generated_stories_english.zip";

        public MlTrainerTest()
        {
            _mlContext = new MLContext(seed: 0);
            _mlDataLoader = new MlDataLoader();
            _mlTrainer = new MlTrainer(_mlContext, _mlDataLoader);
            
        }

        [Fact]
        public void Should_Create_Valid_Zip_File()
        {
            // Act
            _mlTrainer.TrainAndSaveModel();

            // Assert
            Assert.True(File.Exists(path), "ZIP file was not created.");
            Assert.True(new FileInfo(path).Length > 1 * 1024 * 1024, "ZIP file is smaller than 1MB.");

            using var archive = ZipFile.OpenRead(path);
            Assert.True(archive.Entries.Count > 0, "ZIP archive is empty.");
        }
        
        public void Dispose()
        {
            if (File.Exists(path))
                File.Delete(path);
        }
    }
}