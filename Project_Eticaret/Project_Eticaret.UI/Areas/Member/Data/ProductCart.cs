using Project_Eticaret.UI.Areas.Member.Data.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Eticaret.UI.Areas.Member.Data
{
    public class ProductCart
    {
        private Dictionary<Guid, ProductVM> _cart = null;

        public List<ProductVM> CartProductList
        {
            get
            {
                return _cart.Values.ToList();
            }
        }

        public ProductCart()
        {
            _cart = new Dictionary<Guid, ProductVM>();
        }

        #region Sepete Ekle
        public void AddCart(ProductVM item)
        {
            if (!_cart.ContainsKey(item.ID))
            {
                _cart.Add(item.ID, item);
            }
            else
            {
                _cart[item.ID].Quantity++;
            }
        }
        #endregion

        #region Sepetten Sil
        public void RemoveCart(Guid id)
        {
            _cart.Remove(id);
        }
        #endregion

        #region Sepetten Adeti Azalt

        public void DecreaseCart(Guid id)
        {
            _cart[id].Quantity--;

            if (_cart[id].Quantity <= 0)
            {
                _cart.Remove(id);
            }
        }
        #endregion

        #region Sepette Adet Arttır
        public void IncreaseCart(Guid id)
        {
            _cart[id].Quantity++;
        }
        #endregion
    }
}