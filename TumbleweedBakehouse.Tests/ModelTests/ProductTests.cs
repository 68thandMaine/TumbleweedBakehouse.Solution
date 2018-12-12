
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System;
using TumbleweedBakehouse.Models;

namespace TumbleweedBakeHouse.Tests
{

  [TestClass]
  public class ProductTest
  {

    [TestMethod]
    public void ProductConstructor_CreatesInstanceofProduct_Product()
    {
      Product newProduct = new Product ("sourdough","raye","light and fluffy",true,3,1);

      Assert.AreEqual(typeof(Product),newProduct.GetType());
    }






  }
}
