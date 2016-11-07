using System;
using System.Collections.Generic;

namespace JET.Entities
{
    public class Restaurant
    {
        public IEnumerable<Badge> Badges { get; set; }
        public Decimal? Score { get; set; }
        public Decimal? DriveDistance { get; set; }
        public Boolean? DriveInfoCalculated { get; set; }
        public DateTime? NewnessDate { get; set; }
        public Int32? DeliveryMenuId { get; set; }
        public DateTime? DeliveryOpeningTime { get; set; }
        public Decimal? DeliveryCost { get; set; }
        public Decimal? MinimumDeliveryValue { get; set; }
        public Int32? DeliveryTimeMinutes { get; set; }
        public Int32? DeliveryWorkingTimeMinutes { get; set; }
        public DateTime? OpeningTime { get; set; }
        public DateTime? OpeningTimeIso { get; set; }
        public Boolean? SendsOnItsWayNotifications { get; set; }
        public Double? RatingAverage { get; set; }
        public float? Latitude { get; set; }
        public float? Longtitude { get; set; }
        public IEnumerable<Tag> Tags { get; set; }
        public Int32? Id { get; set; }
        public String Name { get; set; }
        public String Address { get; set; }
        public String Postcode { get; set; }
        public String City { get; set; }
        public IEnumerable<CuisineType> CuisineTypes { get; set; }
        public String Url { get; set; }
        public Boolean? IsOpenNow { get; set; }
        public Boolean? IsPremier { get; set; }
        public Boolean? IsSponsored { get; set; }
        public Int32? SponsoredPosition { get; set; }
        public Boolean? IsNew { get; set; }
        public Boolean? IsTemporarilyOffline { get; set; }
        public String ReasonWhyTemporarilyOffline { get; set; }
        public String UniqueName { get; set; }
        public Boolean? IsCloseBy { get; set; }
        public Boolean? IsHalal { get; set; }
        public Boolean? IsTestRestaurant { get; set; }
        public Int32? DefaultDisplayRank { get; set; }
        public Boolean? IsOpenNowForDelivery { get; set; }
        public Boolean IsOpenNowForCollection { get; set; }
        public Decimal? RatingStars { get; set; }
        public IEnumerable<Image> Logo { get; set; }
        public IEnumerable<Deal> Deals { get; set; }
        public Int32? NumberOfRatings { get; set; }
    }
}
