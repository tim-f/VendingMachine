using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace VendingMachine.Core
{
    public class GoodsStore
    {
        private readonly Dictionary<Guid, ProductTray> _products = StartupDefaults.CreateDefaultProductTrayList().ToDictionary(pt => pt.Id);

        public void TakeProductItem(Guid productId)
        {
            var productTray = GetProductTray(productId);
            productTray.TakeOne();

        }

        [NotNull]
        private ProductTray GetProductTray(Guid productId)
        {
            ProductTray productTray;
            if (!_products.TryGetValue(productId, out productTray))
            {
                throw new InvalidOperationException($"Unknown product requested (Id: {productId}).");
            }
            return productTray;
        }
    }
}