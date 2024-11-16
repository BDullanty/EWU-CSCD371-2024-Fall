using Microsoft.VisualStudio.TestPlatform.ObjectModel.DataCollection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Xml;

namespace Assignment.Tests;


//We understand that logic in tests is typically frowned upon, but the assignment recommends we don't use collection assertions,
//Thus we must iterate :)


[TestClass]
public class SampleDataTests
{
    [TestMethod]
    public void CsvRows_IEnumeratorEVC_ContainsAllRows()
    {
        // Arrange
        SampleData sampleData = new(File.ReadAllLines("People.csv"));
        List<string> expectedvalues = File.ReadAllLines("People.csv").Skip(1).ToList();
        // Act
        IEnumerable<string> resultEnumerable = sampleData.CsvRows;

        //  Assert
        Assert.IsNotNull(sampleData);
        Assert.IsNotNull(resultEnumerable);
        Assert.IsTrue(sampleData.CsvRows.Any());
        Assert.AreEqual(expectedvalues.Count, resultEnumerable.Count());
        Assert.AreEqual('1', resultEnumerable.First().First());
        int counter = 0;

        foreach (string value in expectedvalues)
        {
            Assert.AreEqual(value, expectedvalues[counter]);
            counter++;
        }
    }



    [TestMethod]
    public void CsvRows_DVC_ContainsAllRows()
    {
        //Arrange
        SampleData sampleData = new();
        List<string> expectedValues = File.ReadAllLines("People.csv").Skip(1).ToList();
        //Act

        //Assert
        Assert.IsNotNull(sampleData);
        Assert.IsNotNull(expectedValues);
        Assert.AreEqual(expectedValues.Count, sampleData.CsvRows.Count());
        Assert.IsTrue(sampleData.CsvRows.Any());

        Assert.AreEqual('1', sampleData.CsvRows.First().First());

        int counter = 0;
        foreach (string value in sampleData.CsvRows)
        {
            Assert.AreEqual(value, expectedValues[counter]);
            counter++;
        }
    }


    [TestMethod]
    public void CsvRows_StringEVC_ContainsAllRows()
    {
        //Arrange
        SampleData sampleData = new("People.csv");
        List<string> expectedValues = File.ReadAllLines("People.csv").Skip(1).ToList();
        //Act

        //Assert
        Assert.IsNotNull(sampleData);
        Assert.IsNotNull(expectedValues);
        Assert.AreEqual(expectedValues.Count, sampleData.CsvRows.Count());
        Assert.IsTrue(sampleData.CsvRows.Any());

        Assert.AreEqual('1', sampleData.CsvRows.First().First());

        int counter = 0;
        foreach (string value in sampleData.CsvRows)
        {
            Assert.AreEqual(value, expectedValues[counter]);
            counter++;
        }
    }

    [TestMethod]
    public void GetUniqueSortedListOfStatesGivenCsvRows_ReturnsUniqueSortedList()
    {
        //Arrange
        SampleData sampleData = new();
        List<string> expectedResult = ["AZ", "CA", "FL", "GA", "LA", "MD", "MN", "NC", "NV", "NY", "PA", "SC", "TN", "TX", "VA", "WA", "WV"];
        //Act
        IEnumerable<string> resultEnumerable = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();
        //Assert
        Assert.IsNotNull(sampleData);
        Assert.AreEqual(expectedResult.Count, resultEnumerable.Count());

        int counter = 0;
        foreach (string state in resultEnumerable)
        {
            Assert.AreEqual(expectedResult[counter], state);
        }

    }
}