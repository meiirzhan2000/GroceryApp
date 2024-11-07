using System.Web.UI;
using System;
using System.Web.UI.WebControls;

namespace GroceryApp
{
    public class DesignBuilder
    {
        private static void AddToCart_Click(object sender, EventArgs e, string id, string email)
        {
            string productId = id;
            ShoppingCart cart = new ShoppingCart();
            cart.UpdateCart(int.Parse(productId), email);
        }

        public static void addProductItem(Control container, String imageUrl, String productName, String price, String description, String id, String classId, String addToCartUrl, String email)
        {
            Panel productItem = new Panel();
            Panel imageContainer = new Panel();
            Panel textContainer = new Panel();
            Panel detailsContainer = new Panel();

            Image img = new Image();
            Label productNameLabel = new Label();
            Label priceLabel = new Label();
            Label oldPriceLabel = new Label();
            HyperLink viewDetailLink = new HyperLink();
            LinkButton addToCartLink = new LinkButton();

            productItem.CssClass = "col-xl-3 col-lg-4 col-md-6";
            productItem.Style.Add("animation-delay", "0.1s");
            container.Controls.Add(productItem);

            // Image Container
            imageContainer.CssClass = "position-relative bg-light overflow-hidden";
            productItem.Controls.Add(imageContainer);

            img.CssClass = "img-fluid w-100";
            img.Attributes["style"] = "height: 250px; object-fit: cover;";
            img.ImageUrl = imageUrl;
            imageContainer.Controls.Add(img);

            // Text Container
            textContainer.CssClass = "text-center p-4";
            productItem.Controls.Add(textContainer);

            productNameLabel.CssClass = "d-block h5 mb-2";
            productNameLabel.Text = productName;
            textContainer.Controls.Add(productNameLabel);

            priceLabel.CssClass = "text-primary me-1";
            priceLabel.Text = "$" + price;
            textContainer.Controls.Add(priceLabel);

            //oldPriceLabel.CssClass = "text-body text-decoration-line-through";
            //oldPriceLabel.Text = "$" + oldPrice;
            //textContainer.Controls.Add(oldPriceLabel);

            // Details Container
            detailsContainer.CssClass = "d-flex border-top";
            productItem.Controls.Add(detailsContainer);
            
            viewDetailLink.CssClass = "w-50 text-center border-end py-2";
            viewDetailLink.NavigateUrl = $"ProductDetails.aspx?id={id}&image={imageUrl}&name={productName}&price={price}&description={description}&classId={classId}";
            viewDetailLink.Text = "<i class='fa fa-eye text-primary me-2'></i>View detail";
            detailsContainer.Controls.Add(viewDetailLink);

            addToCartLink.CssClass = "w-50 text-center border-end py-2";
            addToCartLink.Text = "<i class='fa fa-shopping-bag text-primary me-2'></i>Add to cart";
            addToCartLink.Click += (sender, e) => AddToCart_Click(sender, e, id, email);
            detailsContainer.Controls.Add(addToCartLink);
        }

        public static void addProductItem(Control container, String imageUrl, String productName, String price, String description, String id, String classId, String addToCartUrl)
        {
            Panel productItem = new Panel();
            Panel imageContainer = new Panel();
            Panel textContainer = new Panel();
            Panel detailsContainer = new Panel();

            Image img = new Image();
            Label productNameLabel = new Label();
            Label priceLabel = new Label();
            Label oldPriceLabel = new Label();
            HyperLink viewDetailLink = new HyperLink();
            HyperLink addToCartLink = new HyperLink();

            productItem.CssClass = "col-xl-3 col-lg-4 col-md-6";
            productItem.Style.Add("animation-delay", "0.1s");
            container.Controls.Add(productItem);

            // Image Container
            imageContainer.CssClass = "position-relative bg-light overflow-hidden";
            productItem.Controls.Add(imageContainer);

            img.CssClass = "img-fluid w-100";
            img.Attributes["style"] = "height: 250px; object-fit: cover;";
            img.ImageUrl = imageUrl;
            imageContainer.Controls.Add(img);

            // Text Container
            textContainer.CssClass = "text-center p-4";
            productItem.Controls.Add(textContainer);

            productNameLabel.CssClass = "d-block h5 mb-2";
            productNameLabel.Text = productName;
            textContainer.Controls.Add(productNameLabel);

            priceLabel.CssClass = "text-primary me-1";
            priceLabel.Text = "$" + price;
            textContainer.Controls.Add(priceLabel);

            //oldPriceLabel.CssClass = "text-body text-decoration-line-through";
            //oldPriceLabel.Text = "$" + oldPrice;
            //textContainer.Controls.Add(oldPriceLabel);

            // Details Container
            detailsContainer.CssClass = "d-flex border-top";
            productItem.Controls.Add(detailsContainer);

            viewDetailLink.CssClass = "w-50 text-center border-end py-2";
            viewDetailLink.NavigateUrl = $"ProductDetails.aspx?id={id}&image={imageUrl}&name={productName}&price={price}&description={description}&classId={classId}";
            viewDetailLink.Text = "<i class='fa fa-eye text-primary me-2'></i>View detail";
            detailsContainer.Controls.Add(viewDetailLink);

            addToCartLink.CssClass = "w-50 text-center border-end py-2";
            addToCartLink.Text = "<i class='fa fa-shopping-bag text-primary me-2'></i>Add to cart";
            addToCartLink.NavigateUrl = "Login.aspx";
            detailsContainer.Controls.Add(addToCartLink);
        }
    }
}