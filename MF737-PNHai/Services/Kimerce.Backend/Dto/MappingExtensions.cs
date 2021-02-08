using AutoMapper;
using Kimerce.Backend.Dto.Models.Employees;
using Kimerce.Backend.Domain.Employees;

namespace Kimerce.Backend.Dto
{
    public static class MappingExtensions
    {
        public static MapperConfiguration MapperConfiguration;

        public static TDestination MapTo<TSource, TDestination>(this TSource source)
        {
            return AutoMapperConfig.Mapper.Map<TSource, TDestination>(source);
        }
        public static TDestination MapTo<TSource, TDestination>(this TSource source, TDestination destination)
        {
            return AutoMapperConfig.Mapper.Map(source, destination);
        }

        //#region City
        //public static CityModel ToModel(this City entity)
        //{
        //    return entity.MapTo<City, CityModel>();
        //}

        //public static CityItem ToItem(this City entity)
        //{
        //    return entity.MapTo<City, CityItem>();
        //}

        //public static City ToCity(this CityModel model)
        //{
        //    return model.MapTo<CityModel, City>();
        //}

        //public static City ToCity(this City entity, City destination)
        //{
        //    return entity.MapTo(destination);
        //}
        //#endregion
        //#region Shipments
        //public static Shipment ToShipment(this Shipment entity, Shipment destination)
        //{
        //    return entity.MapTo(destination);
        //}
        //public static ShipmentModel ToModel(this Shipment entity)
        //{

        //    return entity.MapTo<Shipment, ShipmentModel>();
        //}
        //public static Shipment ToShipment(this ShipmentModel model)
        //{
        //    return model.MapTo<ShipmentModel, Shipment>();
        //}
        //public static Shipment_Item ToItem(this Shipment entity)
        //{
        //    return entity.MapTo<Shipment, Shipment_Item>();
        //}
        //#endregion

        //#region District
        //public static DistrictModel ToModel(this District entity)
        //{
        //    return entity.MapTo<District, DistrictModel>();
        //}

        //public static DistrictItem ToItem(this District entity)
        //{
        //    return entity.MapTo<District, DistrictItem>();
        //}

        //public static District ToDistrict(this DistrictModel model)
        //{
        //    return model.MapTo<DistrictModel, District>();
        //}

        //public static District ToDistrict(this District entity, District destination)
        //{
        //    return entity.MapTo(destination);
        //}
        //#endregion

        //#region Ward
        //public static WardModel ToModel(this Ward entity)
        //{
        //    return entity.MapTo<Ward, WardModel>();
        //}

        //public static WardItem ToItem(this Ward entity)
        //{
        //    return entity.MapTo<Ward, WardItem>();
        //}

        //public static Ward ToWard(this WardModel model)
        //{
        //    return model.MapTo<WardModel, Ward>();
        //}

        //public static Ward ToWard(this Ward entity, Ward destination)
        //{
        //    return entity.MapTo(destination);
        //}
        //#endregion

        //#region Warehouse
        //public static WareHouseModel ToModel(this WareHouse entity)
        //{
        //    return entity.MapTo<WareHouse, WareHouseModel>();
        //}

        //public static WareHouseItem ToItem(this WareHouse entity)
        //{
        //    return entity.MapTo<WareHouse, WareHouseItem>();
        //}

        //public static WareHouse ToWareHouse(this WareHouseModel model)
        //{
        //    return model.MapTo<WareHouseModel, WareHouse>();
        //}

        //public static WareHouse ToWareHouse(this WareHouse entity, WareHouse destination)
        //{
        //    return entity.MapTo(destination);
        //}
        //#endregion

        //#region ProductCategory
        //public static ProductCategory ToProductCategory(this ProductCategory entity, ProductCategory destination)
        //{
        //    return entity.MapTo(destination);
        //}

        //public static ProductCategoryModel ToModel(this ProductCategory entity)
        //{
        //    return entity.MapTo<ProductCategory, ProductCategoryModel>();
        //}
       
        //public static ProductCategoryItem ToItem(this ProductCategory entity)
        //{
        //    return entity.MapTo<ProductCategory, ProductCategoryItem>();
        //}
        //public static ProductCategory ToProductCategory(this ProductCategoryModel model)
        //{
        //    return model.MapTo<ProductCategoryModel, ProductCategory>();
        //}
        //#endregion

        //#region Product
        //public static ProductModel ToModel(this Product entity)
        //{
        //    return entity.MapTo<Product, ProductModel>();
        //}
        //public static ProductItem ToItem(this Product entity)
        //{
        //    return entity.MapTo<Product, ProductItem>();
        //}

        //public static Product ToProduct(this ProductModel model)
        //{
        //    return model.MapTo<ProductModel, Product>();
        //}

        //public static Product ToProduct(this Product entity, Product destination)
        //{
        //    return entity.MapTo(destination);
        //}
        //#endregion

        //#region RelateProduct
        //public static RelateProductItem ToItem(this RelateProduct entity)
        //{
        //    return entity.MapTo<RelateProduct, RelateProductItem>();
        //}
        
        //public static RelateProductModel ToModel(this RelateProduct entity)
        //{
        //    return entity.MapTo<RelateProduct, RelateProductModel>();
        //}

        //public static RelateProduct ToRelateProduct(this RelateProductModel model)
        //{
        //    return model.MapTo<RelateProductModel, RelateProduct>();
        //}

        //public static RelateProduct ToRelateProduct(this RelateProduct entity, RelateProduct destination)
        //{
        //    return entity.MapTo(destination);
        //}

        //#endregion

        //#region ProductImage
        //public static ProductImageItem ToItem(this ProductImage entity)
        //{
        //    return entity.MapTo<ProductImage, ProductImageItem>();
        //}

        //public static ProductImageModel ToModel(this ProductImage entity)
        //{
        //    return entity.MapTo<ProductImage, ProductImageModel>();
        //}

        //public static ProductImage ToProductImage(this ProductImageModel model)
        //{
        //    return model.MapTo<ProductImageModel, ProductImage>();
        //}

        //public static ProductImage ToProductImage(this ProductImage entity, ProductImage destination)
        //{
        //    return entity.MapTo(destination);
        //}

        //#endregion

        //#region Setting
        //public static Setting ToSetting(this Setting entity, Setting destination)
        //{
        //    return entity.MapTo(destination);
        //}

        //public static Setting ToSetting(this SettingItem entity)
        //{
        //    return entity.MapTo<SettingItem, Setting>();
        //}
        //public static SettingItem ToItem(this Setting entity)
        //{
        //    return entity.MapTo<Setting, SettingItem>();
        //}
        //#endregion
        //#region Email
        //#region EmailProvider
        //public static EmailProvider ToEmailProvider(this EmailProvider entity, EmailProvider destination)
        //{
        //    return entity.MapTo(destination);
        //}
        //public static EmailProvider ToEmailProvider(this EmailProviderItem entity)
        //{
        //    return entity.MapTo<EmailProviderItem, EmailProvider>();
        //}
        //public static EmailProviderItem ToItem(this EmailProvider entity)
        //{
        //    return entity.MapTo<EmailProvider, EmailProviderItem>();
        //}
        //#endregion
        //#region EmailAccount
        //public static EmailAccount ToEmailAccount(this EmailAccount entity, EmailAccount destination)
        //{
        //    return entity.MapTo(destination);
        //}
        //public static EmailAccount ToEmailAccount(this EmailAccountItem entity)
        //{
        //    return entity.MapTo<EmailAccountItem, EmailAccount>();
        //}
        //public static EmailAccountItem ToItem(this EmailAccount entity)
        //{
        //    return entity.MapTo<EmailAccount, EmailAccountItem>();
        //}
        //#endregion
        //#region EmailTemplate
        //public static EmailTemplate ToEmailTemplate(this EmailTemplate entity, EmailTemplate destination)
        //{
        //    return entity.MapTo(destination);
        //}
        //public static EmailTemplate ToEmailTemplate(this EmailTemplateItem entity)
        //{
        //    return entity.MapTo<EmailTemplateItem, EmailTemplate>();
        //}
        //public static EmailTemplateItem ToItem(this EmailTemplate entity)
        //{
        //    return entity.MapTo<EmailTemplate, EmailTemplateItem>();
        //}
        //#endregion
        //#region Email
        //public static Email ToEmail(this Email entity, Email destination)
        //{
        //    return entity.MapTo(destination);
        //}
        //public static Email ToEmail(this EmailItem entity)
        //{
        //    return entity.MapTo<EmailItem, Email>();
        //}
        //public static EmailItem ToItem(this Email entity)
        //{
        //    return entity.MapTo<Email, EmailItem>();
        //}
        //#endregion
        //#endregion
        //#region ShipmentItems
        //public static ShipmentItem ToShipmentItem(this ShipmentItem entity, ShipmentItem destination)
        //{
        //    return entity.MapTo(destination);
        //}
        //public static ShipmentItemModel ToModel(this ShipmentItem entity)
        //{
        //    return entity.MapTo<ShipmentItem, ShipmentItemModel>();
        //}
        //public static ShipmentItem ToShipmentItem(this ShipmentItemModel model)
        //{
        //    return model.MapTo<ShipmentItemModel, ShipmentItem>();
        //}


        //public static ShipmentItem_Item ToItem(this ShipmentItem entity)
        //{
        //    return entity.MapTo<ShipmentItem, ShipmentItem_Item>();
        //}

        //#endregion
        //#region Order



        //public static OrderModel ToModel(this Order entity)
        //{
        //    return entity.MapTo<Order, OrderModel>();
        //}

        //public static OrderItem ToItem(this Order entity)
        //{
        //    return entity.MapTo<Order, OrderItem>();
        //}
        //public static Order ToOrder(this Order entity, Order destination)
        //{
        //    return entity.MapTo(destination);
        //}
        //public static Order ToOrder(this OrderModel entity)
        //{
        //    return entity.MapTo<OrderModel, Order>();
        //}


        //public static Items.Orders.OrderItemItem ToItem(this Domain.Orders.Order_Item entity)
        //{
        //    return entity.MapTo<Domain.Orders.Order_Item, Items.Orders.OrderItemItem>();
        //}
        //public static Domain.Orders.Order_Item ToOrderItem(this Domain.Orders.Order_Item entity, Domain.Orders.Order_Item destination)
        //{
        //    return entity.MapTo(destination);
        //}
        //public static Domain.Orders.Order_Item ToOrderItem(this OrderItemModel entity)
        //{
        //    return entity.MapTo<OrderItemModel, Domain.Orders.Order_Item>();
        //}
        //public static OrderItemModel ToModel(this Order_Item entity)
        //{
        //    return entity.MapTo<Order_Item, OrderItemModel>();
        //}

        //#endregion

        //#region Image



        //public static ImageModel ToModel(this Image entity)
        //{
        //    return entity.MapTo<Image, ImageModel>();
        //}

        //public static ImageItem ToItem(this Image entity)
        //{
        //    return entity.MapTo<Image, ImageItem>();
        //}
        //public static Image ToImage(this Image entity, Image destination)
        //{
        //    return entity.MapTo(destination);
        //}
        //public static Image ToImage(this ImageModel entity)
        //{
        //    return entity.MapTo<ImageModel, Image>();
        //}



        //#endregion
        //#region News



        //public static NewsModel ToModel(this News entity)
        //{
        //    return entity.MapTo<News, NewsModel>();
        //}

        //public static NewsModel ToNews(this News entity)
        //{
        //    return entity.MapTo<News, NewsModel>();
        //}
        //public static News ToNews(this News entity, News destination)
        //{
        //    return entity.MapTo(destination);
        //}
        //public static News ToNews(this NewsModel entity)
        //{
        //    return entity.MapTo<NewsModel, News>();
        //}


        //#endregion

        //#region Campaigns
        //#region Campaign
        //public static Campaign ToCampaign(this Campaign entity, Campaign destination)
        //{
        //    return entity.MapTo(destination);
        //}
        //public static Campaign ToCampaign(this CampaignItem entity)
        //{
        //    return entity.MapTo<CampaignItem, Campaign>();

        //}
        //public static CampaignItem ToItem(this Campaign entity)
        //{
        //    return entity.MapTo<Campaign, CampaignItem>();
        //}

        //public static Campaign ToCampaign(this CampaignItem entity, Campaign destination)

        //{
        //    return entity.MapTo(destination);
        //}

        //#endregion

        //#region Discount
        //public static DiscountModel ToModel(this Discount entity)
        //{
        //    return entity.MapTo<Discount, DiscountModel>();
        //}
        //public static Discount ToDiscount(this DiscountModel model)
        //{
        //    return model.MapTo<DiscountModel, Discount>();
        //}

        //public static DiscountItem ToItem(this Discount entity)
        //{
        //    return entity.MapTo<Discount, DiscountItem>();
        //}

        //public static Discount ToDiscount(this Discount entity, Discount destination)
        //{
        //    return entity.MapTo(destination);
        //}

        //#endregion

        //#region CampaignProduct
        //public static CampaignProductModel ToModel(this CampaignProduct entity)
        //{
        //    return entity.MapTo<CampaignProduct, CampaignProductModel>();
        //}
        //public static CampaignProductItem ToItem(this CampaignProduct entity)
        //{
        //    return entity.MapTo<CampaignProduct, CampaignProductItem>();
        //}

        //public static CampaignProduct ToCampaignProduct(this CampaignProductModel model)
        //{
        //    return model.MapTo<CampaignProductModel, CampaignProduct>();
        //}

        //public static CampaignProduct ToCampaignProduct(this CampaignProduct entity, CampaignProduct destination)
        //{
        //    return entity.MapTo(destination);
        //}
        //#endregion

        //#region CampaignOrder
        //public static CampaignOrderModel ToModel(this CampaignOrder entity)
        //{
        //    return entity.MapTo<CampaignOrder, CampaignOrderModel>();
        //}
        //public static CampaignOrderItem ToItem(this CampaignOrder entity)
        //{
        //    return entity.MapTo<CampaignOrder, CampaignOrderItem>();
        //}

        //public static CampaignOrder ToCampaignOrder(this CampaignOrderModel model)
        //{
        //    return model.MapTo<CampaignOrderModel, CampaignOrder>();
        //}

        //public static CampaignOrder ToCampaignOrder(this CampaignOrder entity, CampaignOrder destination)
        //{
        //    return entity.MapTo(destination);
        //}
        //#endregion

        //#region DiscountOrder
        //public static DiscountOrderModel ToModel(this DiscountOrder entity)
        //{
        //    return entity.MapTo<DiscountOrder, DiscountOrderModel>();
        //}
        //public static DiscountOrderItem ToItem(this DiscountOrder entity)
        //{
        //    return entity.MapTo<DiscountOrder, DiscountOrderItem>();
        //}

        //public static DiscountOrder ToDiscountOrder(this DiscountOrderModel model)
        //{
        //    return model.MapTo<DiscountOrderModel, DiscountOrder>();
        //}

        //public static DiscountOrder ToDiscountOrder(this DiscountOrder entity, DiscountOrder destination)
        //{
        //    return entity.MapTo(destination);
        //}
        //#endregion
        //#endregion
        //#region Notification
        //public static NotificationModel ToModel(this Notification entity)
        //{
        //    return entity.MapTo<Notification, NotificationModel>();
        //}
        //public static Notification ToNotification(this NotificationModel model)
        //{
        //    return model.MapTo<NotificationModel, Notification>();
        //}

        //public static Notification ToNotification(this Notification entity, Notification destination)
        //{
        //    return entity.MapTo(destination);
        //}

        //public static Notification_OrderItem ToItem(this Notification_Order entity)
        //{
        //    return entity.MapTo<Notification_Order, Notification_OrderItem>();
        //}
        //public static Notification_Order ToNotification_Order(this Notification_Order entity, Notification_Order destination)
        //{
        //    return entity.MapTo(destination);
        //}
        //public static Notification_Order ToNotification_Order(this Notification_OrderModel entity)
        //{
        //    return entity.MapTo<Notification_OrderModel, Notification_Order>();
        //}

        //public static Notification_ImageItem ToItem(this Notification_Image entity)
        //{
        //    return entity.MapTo<Notification_Image, Notification_ImageItem>();
        //}
        //public static Notification_Image ToNotification_Image(this Notification_Image entity, Notification_Image destination)
        //{
        //    return entity.MapTo(destination);
        //}
        //public static Notification_Image ToNotification_Image(this Notification_ImageModel entity)
        //{
        //    return entity.MapTo<Notification_ImageModel, Notification_Image>();
        //}


        //#endregion

        //#region Tracking

        //public static TrackingModel ToModel(this Tracking entity)
        //{
        //    return entity.MapTo<Tracking, TrackingModel>();
        //}
        //public static Tracking ToTracking(this TrackingModel model)
        //{
        //    return model.MapTo<TrackingModel, Tracking>();
        //}

        //public static Tracking ToTracking(this Tracking entity, Tracking destination)
        //{
        //    return entity.MapTo(destination);
        //}
        //public static AttributeValue ToAttributeValue(this AttributeValue entity, AttributeValue destination)
        //{
        //    return entity.MapTo(destination);
        //}
        //#endregion


        //#region Attribute
        //public static AttributeModel ToModel(this Attribute entity)
        //{
        //    return entity.MapTo<Attribute, AttributeModel>();
        //}
        //public static AttributeItem ToItem(this Attribute entity)
        //{
        //    return entity.MapTo<Attribute, AttributeItem>();
        //}

        //public static Attribute ToAttribute(this AttributeModel model)
        //{
        //    return model.MapTo<AttributeModel, Attribute>();
        //}

        //public static Attribute ToAttribute(this Attribute entity, Attribute destination)
        //{
        //    return entity.MapTo(destination);
        //}
        //#endregion

        //#region AttributeValue
        //public static AttributeValueModel ToModel(this AttributeValue entity)
        //{
        //    return entity.MapTo<AttributeValue, AttributeValueModel>();
        //}
        //public static AttributeValueItem ToItem(this AttributeValue entity)
        //{
        //    return entity.MapTo<AttributeValue, AttributeValueItem>();
        //}

        //public static AttributeValue ToAttributeValue(this AttributeValueModel model)
        //{
        //    return model.MapTo<AttributeValueModel, AttributeValue>();
        //}
        //#endregion

        //#region SpecAttribute
        //public static SpecAttributeModel ToModel(this SpecAttribute entity)
        //{
        //    return entity.MapTo<SpecAttribute, SpecAttributeModel>();
        //}
        //public static SpecAttributeItem ToItem(this SpecAttribute entity)
        //{
        //    return entity.MapTo<SpecAttribute, SpecAttributeItem>();
        //}

        //public static SpecAttribute ToSpecAttribute(this SpecAttributeModel model)
        //{
        //    return model.MapTo<SpecAttributeModel, SpecAttribute>();
        //}

        //public static SpecAttribute ToSpecAttribute(this SpecAttribute entity, SpecAttribute destination)
        //{
        //    return entity.MapTo(destination);
        //}
        //#endregion

        //#region InventoryAttribute
        //public static InventoryAttributeModel ToModel(this InventoryAttribute entity)
        //{
        //    return entity.MapTo<InventoryAttribute, InventoryAttributeModel>();
        //}
        //public static InventoryAttributeItem ToItem(this InventoryAttribute entity)
        //{
        //    return entity.MapTo<InventoryAttribute, InventoryAttributeItem>();
        //}

        //public static InventoryAttribute ToInventoryAttribute(this InventoryAttributeModel model)
        //{
        //    return model.MapTo<InventoryAttributeModel, InventoryAttribute>();
        //}

        //public static InventoryAttribute ToInventoryAttribute(this InventoryAttribute entity, InventoryAttribute destination)
        //{
        //    return entity.MapTo(destination);
        //}
        //#endregion

        //#region ProductPiece
        //public static ProductPieceModel ToModel(this ProductPiece entity)
        //{
        //    return entity.MapTo<ProductPiece, ProductPieceModel>();
        //}
        //public static ProductPieceItem ToItem(this ProductPiece entity)
        //{
        //    return entity.MapTo<ProductPiece, ProductPieceItem>();
        //}

        //public static ProductPiece ToProductPiece(this ProductPieceModel model)
        //{
        //    return model.MapTo<ProductPieceModel, ProductPiece>();
        //}

        //public static ProductPiece ToProductPiece(this ProductPiece entity, ProductPiece destination)
        //{
        //    return entity.MapTo(destination);
        //}
        //#endregion


        #region Employee
        public static EmployeeModel ToModel(this Employee entity)
        {
            return entity.MapTo<Employee, EmployeeModel>();
        }

        public static Employee ToEmployee(this EmployeeModel model)
        {
            return model.MapTo<EmployeeModel, Employee>();
        }
        public static Employee ToEmployee(this Employee entity, Employee destination)
        {
            return entity.MapTo(destination);
        }


        #endregion
    }
}
