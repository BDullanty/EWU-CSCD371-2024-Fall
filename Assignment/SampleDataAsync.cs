﻿using System.Linq;
namespace Assignment;


public class SampleDataAsync : IAsyncSampleData
{

    // 1.
    private IAsyncEnumerable<string>? _csvRows;

    public IAsyncEnumerable<string> CsvRows
    {
        get => _csvRows!;
        set => _csvRows = value?.Skip(1) ?? AsyncEnumerable.Empty<string>();
    }

    //We want to load the file async on construction
    public SampleDataAsync()
    {
        CsvRows = File.ReadLinesAsync("People.csv");
    }


    //2
    public IAsyncEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
    {
        return CsvRows.Select(row => row.Split(',')[6]).Distinct().OrderBy(state => state);
    }
    //3
    public string GetAggregateSortedListOfStatesUsingCsvRows()
    {
        throw new NotImplementedException();
    }


    //4
    public IAsyncEnumerable<IPerson> People => throw new NotImplementedException();

    //5
    public IAsyncEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(Predicate<string> filter)
    {
        throw new NotImplementedException();
    }
    //6
    public string GetAggregateListOfStatesGivenPeopleCollection(IAsyncEnumerable<IPerson> people)
    {
        throw new NotImplementedException();
    }

}
