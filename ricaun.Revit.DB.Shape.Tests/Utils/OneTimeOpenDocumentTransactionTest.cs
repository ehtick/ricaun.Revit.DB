using Autodesk.Revit.DB;
using NUnit.Framework;

namespace ricaun.Revit.DB.Shape.Tests.Utils
{
    /// <summary>
    /// OneTimeOpenDocumentTransactionTest
    /// </summary>
    public class OneTimeOpenDocumentTransactionTest : OneTimeOpenDocumentTest
    {
        protected virtual string TransactionName => null;
        protected Transaction transaction;
        [SetUp]
        public void Setup()
        {
            transaction?.Dispose();
            transaction = new Transaction(document);
            transaction.Start(TransactionName ?? this.GetType().Name);
        }
        [TearDown]
        public void TearDown()
        {
            transaction.Commit();
            transaction.Dispose();
            transaction = null;
        }
    }
}