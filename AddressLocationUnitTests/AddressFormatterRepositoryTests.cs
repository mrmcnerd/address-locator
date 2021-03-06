﻿using System;
using AddressLocator;
using AddressLocator.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AddressLocationUnitTests
{
    [TestClass]
    public class AddressFormatterRepositoryTests
    {
        private IAddressFormatterRepository formatters;
        private Address address;
        private Country ireland;

        [TestInitialize]
        public void AddressFormatterRepository_Initialiser()
        {
            formatters = new MockAddressFormatterRepository();
            address = new Address(formatters.Default);
            ireland = new Country { Name = "Ireland", Code = "IE" };
            address.Address1 = "1 Main Street";
            address.City = "Kilcullen";
            address.Region = "Co. Kildare";
            address.Country = ireland;
        }

        [TestMethod, TestCategory("Repositories")]
        public void AddressFormatterRepository_TestDefault()
        {
            IAddressFormatter formatter = formatters.Default;
            string formattedAddress = formatter.Format(address);
            Assert.AreEqual("1 Main Street,Kilcullen,Co. Kildare,Ireland", formattedAddress);
        }

        [TestMethod, TestCategory("Repositories")]
        public void AddressFormatterRepository_TestMissing()
        {
            IAddressFormatter formatter = formatters.Get("Non Existant Formatter");
            string formattedAddress = formatter.Format(address);
            // should revert to default formatter...
            Assert.AreEqual("1 Main Street,Kilcullen,Co. Kildare,Ireland", formattedAddress);
        }

        [TestMethod, TestCategory("Repositories")]
        public void AddressFormatterRepository_TestMockFormatter()
        {
            IAddressFormatter formatter = formatters.Get("Test");
            string formattedAddress = formatter.Format(address);
            // Mock formatter should display the address backwards.
            Assert.AreEqual("Ireland,Co. Kildare,Kilcullen,1 Main Street", formattedAddress);
        }

    }
}
