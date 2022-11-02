//using CKK.Logic.Models;
//using CKK.Logic.Exceptions;
//using CKK.Logic.Interfaces;
//using System.IO;
//using System.Runtime.Serialization;
//using System.Runtime.Serialization.Formatters.Binary;
//using System.ComponentModel;
//using CKK.Persistence.Interfaces;

//namespace CKK.Persistence.Models
//{
//    public class FileStore : Entity, IStore, ISavable, ILoadable
//    {
//        private static List<StoreItem> Items;

//        string FilePath = @"C:\Users\vreed\Documents\Persistence\StoreItem.dat"; /**** FOR HOME DESKTOP ****/
//        string FilePath_NewProduct = @"C:\Users\vreed\Documents\Persistence\NewProduct.dat"; /**** FOR HOME DESKTOP ****/
//        //string FilePath = @"C:\Users\ryanl\Documents\Persistence\StoreItems.dat"; /**** FOR RAZER BLADE LAPTOP ****/
//        //string FilePath_NewProduct = @"C:\Users\ryanl\Documents\Persistence\NewProduct.dat"; /**** FOR RAZER BLADE LAPTOP ****/
//        //string FilePath = @"C:\Users\4400113921\Desktop\Documents\Persistence\StoreItems.dat"; /**** FOR OTECH DESKTOP ****/
//        //string FilePath_NewProduct = @"C:\Users\4400113921\Desktop\Documents\Persistence\NewProduct.dat"; /**** FOR OTECH DESKTOP ****/

//        // For Save and Load methods below
//        // Object for serializing in the binary format 
//        // private BinaryFormatter formatter = new BinaryFormatter();
//        // private FileStream output; // Stream for reading from the file


//        public StoreItem AddStoreItem(Product prod, int quant)
//        {
//            // Initialize new ID numbers
//            int newId = 101;

//            // If the item already exists in the List,
//            // then you should add the quantity variable of that item and not add new StoreItem.
//            if (quant > 0)
//            {
//                StoreItem myItem = FindStoreItemById(prod.Id);

//                if (myItem != null && prod.Id != 0)  // If product's current ID is 0, give product new ID
//                {
//                    myItem.Quantity += quant;
//                }
//                else
//                {
//                    myItem = new StoreItem(prod, quant);
//                    myItem.Product.Id = newId;  // Give store item with 0 as current ID new id, beginning with 101
//                    newId++; // Increment newId
//                    Items.Add(myItem);
//                }
//                return myItem;
//            }
//            else
//            {
//                throw new InventoryItemStockTooLowException("The value entered must be a postive number");
//            }
//        }

//        public StoreItem RemoveStoreItem(int id, int quant)
//        {
//            // If the product does not exist, throw ProductDoesNotExistException
//            if (FindStoreItemById(id) == null)
//            {
//                throw new ProductDoesNotExistException();
//            }

//            //If the value is going to be less than zero,
//            //then it should stay at 0,
//            // and NOT remove the item from the store
//            if (quant > 0)
//            {

//                foreach (StoreItem item in Items)
//                {
//                    if (id == item.Product.Id)
//                    {
//                        if (item.Quantity - quant > 0)
//                        {
//                            item.Quantity -= quant;
//                            return item;
//                        }
//                        else
//                        {
//                            item.Quantity = 0;
//                            return item;
//                        }
//                    }
//                }
//            }
//            else
//            {
//                throw new ArgumentOutOfRangeException("The value entered must be a postive number");
//            }

//            return null;
//        }

//        public StoreItem FindStoreItemById(int id)
//        {

//            if (id < 0) // Validate
//            {
//                throw new InvalidIdException("The value entered must be a postive number");
//            }


//            //This will return the product that has the same Id(if there is one)
//            var findStoreItemId =
//                from item in Items
//                where item.Product.Id == id
//                select item;

//            return findStoreItemId.FirstOrDefault();
//        }

//        public List<StoreItem> GetStoreItems()
//        {
//            //Should return correct product
//            //If it is an invalid productNumber, then it will return null
//            //If there is not an item in the desired spot, it will return null
//            return Items;
//        }

//        public void Load()
//        {
//            BinaryFormatter reader = new BinaryFormatter();
//            FileStream input; // Stream for reading from the file

//            // Create FileStream to obtain read access to file
//            input = new FileStream(FilePath, FileMode.Open, FileAccess.Read);
//        }


//        /*** SAVE SINGLE ITEM WITH ADD METHOD IN MANAGEPRODUCTS ****/
//        public void Save(Product product, string productDescription, int quantity)
//        {
//            //using (StreamWriter streamWriter = new StreamWriter(@"C:\Users\vreed\Documents\Persistence\StoreItem.dat")) /**** FOR HOME PC ****/
//            //using (StreamWriter streamWriter = new StreamWriter(FilePath_NewProduct)) /**** FOR RAZER BLADE LAPTOP ****/
//            //using (StreamWriter streamWriter = new StreamWriter(@"C:\Users\4400113921\Desktop\Documents\Persistence\StoreItems.dat")) /**** FOR OTECH PC ****/
//            //{
//            //    streamWriter.WriteLine($"ID:\t\t{product.Id,10:D3}\n" +
//            //                           $"Name:\t\t{product.Name,10}\n" +
//            //                           $"Description:\t{productDescription,10}\n" +
//            //                           $"Price:\t\t{product.Price,10:C}\n" +
//            //                           $"Quantity:\t\t{quantity,10}\n");
//            //}
//        }

//        public static void CreatePath()
//        {
//            //Write the string array to a new file named "WriteLines.txt".
//            // FROM DELIVERABLE 12 TUTORIAL
//            // Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + Path.DirectorySeparatorChar + "Persistance" + Path.DirectorySeparatorChar + "StoreItems.dat";

//            try
//            {
//                using (StreamWriter streamWriter = new StreamWriter(@"C:\Users\vreed\Documents\Persistence\StoreItem.dat")) /**** FOR HOME PC ****/
//                // using (StreamWriter streamWriter = new StreamWriter(@"C:\Users\ryanl\Documents\Persistence\StoreItems.dat")) /**** FOR RAZER BLADE LAPTOP ****/
//                //using (StreamWriter streamWriter = new StreamWriter(@"C:\Users\4400113921\Desktop\Documents\Persistence\StoreItems.dat")) /**** FOR OTECH PC ****/
//                {
//                    //foreach (string line in lines)
//                    //    outputFile.WriteLine(line);
//                    //for (StoreItem i = Items[0]; i < ; i++)
//                    //{
//                    //    streamWriter.WriteLine(i);
//                    //}
//                    foreach (StoreItem storeItem in Items)
//                    {
//                        streamWriter.WriteLine(storeItem);
//                    }
//                }
//            }
//            catch (IOException)
//            {

//            }
//        }

//        public StoreItem DeleteStoreItem(int id)
//        {
//            throw new NotImplementedException();
//        }

//        // public List<StoreItem> GetAllProductsByName(string name) 
//        // {
//        //    return Items.Where(name => StoreItem.Name).ToList();
//        // }

//        // public List<StoreItem> GetProductsByQuantity(int quant)
//        // {
//        //    return Items.Where(quant => StoreItem.Quantity).ToList();
//        // }

//        // public List<StoreItem> GetProductsByPrice(decimal price)
//        // {
//        //    return Items.Where(price => StoreItem.Price).ToList();
//        // }
//    }
//}
