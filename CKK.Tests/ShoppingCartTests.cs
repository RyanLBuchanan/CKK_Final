//using System;
//using Xunit;
//using Xunit.Sdk;
//using CKK.Logic.Models;

//namespace CKK.Tests
//{
//    public class ShoppingCartTests
//    {
//        [Fact]
//        public void AddProduct_AddProductWhenExists()
//        {
//            try
//            {
//                //Assemble
//                Customer cust = new Customer();
//                cust.SetId(1);
//                ShoppingCart cart = new ShoppingCart(cust);

//                //Act
//                var _product1 = new Product();
//                _product1.SetId(1);
//                var _product2 = new Product();
//                _product2.SetId(2);
//                var _product3 = new Product();
//                _product3.SetId(3);

//                cart.AddProduct(_product1);
//                cart.AddProduct(_product2);
//                cart.AddProduct(_product3);

//                var returnedItem = cart.AddProduct(_product1, 3);
//                var expected = 4;

//                //Assert
//                var actual = cart.GetProduct(1).GetQuantity();
//                Assert.Equal(expected, returnedItem.GetQuantity());
//                Assert.Equal(expected, actual);
//            }
//            catch
//            {
//                throw new XunitException("The product was added incorrectly.");
//            }
//        }

//        [Fact]
//        public void AddProduct_AddProductWhenFull()
//        {
//            try
//            {
//                //Assemble
//                Customer cust = new Customer();
//                cust.SetId(1);
//                ShoppingCart cart = new ShoppingCart(cust);

//                //Act
//                var _product1 = new Product();
//                _product1.SetId(1);
//                var _product2 = new Product();
//                _product2.SetId(2);
//                var _product3 = new Product();
//                _product3.SetId(3);

//                cart.AddProduct(_product1, 1);
//                cart.AddProduct(_product2, 1);
//                cart.AddProduct(_product3, 1);

//                var returnedItem = cart.AddProduct(_product1, 3);
//                var expected = 4;

//                //Assert
//                var actual = cart.GetProduct(1).GetQuantity();
//                Assert.Equal(expected, returnedItem.GetQuantity());
//                Assert.Equal(expected, actual);
//            }
//            catch
//            {
//                throw new XunitException("The product was not added.");
//            }
//        }

//        [Fact]
//        public void ShouldRemoveProduct()
//        {
//            try
//            {
//                //Assemble
//                Store store = new();
//                var product1 = new Product();
//                var product2 = new Product();
//                var product3 = new Product();
//                store.AddStoreItem(product1);
//                store.AddStoreItem(product2);
//                store.AddStoreItem(product3);

//                //Act
//                store.RemoveStoreItem(1);

//                //Assert
//                Assert.Null(store.GetStoreItem(1));
//            }
//            catch
//            {
//                throw new XunitException("The product was not removed correctly.");
//            }
//        }

//        [Fact]
//        public void ShouldGetTotal()
//        {
//            try
//            {
//                //Assemble
//                var price = 4.0m;
//                var quantity = 2;
//                var expected = 8m;
//                var testProduct = new Product();
//                testProduct.SetPrice(price);

//                var cartItem = new ShoppingCartItem(testProduct, quantity);
//                //Act
//                var actual = cartItem.GetTotal();
//                //Assert
//                Assert.Equal(expected, actual);
//            }
//            catch
//            {
//                throw new XunitException("The product total was added incorrectly.");
//            }
//        }
//    }
//}