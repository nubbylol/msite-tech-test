using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Program.Implementations;

namespace Program.Tests;

[TestClass]
public class DataContextTests
{
    [TestMethod]
    public void Can_get_Departments()
    {
        var dataContext = new DataContext();
        
        var result = dataContext.Departments;
        
        Assert.IsNotNull(result);
        Assert.IsTrue(result.Any());
    }
    
    [TestMethod]
    public void Can_get_Persons()
    {
        var dataContext = new DataContext();

        var result = dataContext.Persons;
        
        Assert.IsNotNull(result);
        Assert.IsTrue(result.Any());
    }

    [DataTestMethod]
    [DataRow("Purchasing")]
    [DataRow("Sales")]
    public void Can_get_Surnames_by_Department(string departmentName)
    {
        var dataContext = new DataContext();
        var expectedSurnames = GetExpectedSurnames(dataContext, departmentName);

        var result = dataContext.GetSurnames(departmentName);
        
        CollectionAssert.AreEqual(result, expectedSurnames);
    }

    [TestMethod]
    public void Throws_error_when_Department_does_not_exist()
    {
        var nonExistentDepartmentName = "safasfsa";
        var dataContext = new DataContext();
        
        Assert.ThrowsException<NotImplementedException>(() => dataContext.GetSurnames(nonExistentDepartmentName));
    }

    #region Helpers

    private List<string> GetExpectedSurnames(DataContext dataContext, string departmentName)
    {
        var expectedSurnames = dataContext.Departments.FirstOrDefault(x => x.Name == departmentName)
            ?.Members.Select(x => x.Surname)
            .ToList();

        return expectedSurnames;
    }

    #endregion
}