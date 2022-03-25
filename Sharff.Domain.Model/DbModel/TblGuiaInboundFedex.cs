using System;
using System.Collections.Generic;

#nullable disable

namespace Sharff.Domain.Model.DbModel
{
    public partial class TblGuiaInboundFedex
    {
        public string AbHdr { get; set; }
        public string Orig { get; set; }
        public string Dest { get; set; }
        public string OriginCountry { get; set; }
        public string ExportCountry { get; set; }
        public string ShipDate { get; set; }
        public string ConsigneeAccount { get; set; }
        public string ConsigneePhone { get; set; }
        public string ConsigneeCompany { get; set; }
        public string ConsigneeName { get; set; }
        public string ConsigneeAddress1 { get; set; }
        public string ConsigneeAddress2 { get; set; }
        public string ConsigneeCity { get; set; }
        public string ConsigneeStPv { get; set; }
        public string ConsigneeCountry { get; set; }
        public string ConsigneePostal { get; set; }
        public string ShipperAccount { get; set; }
        public string ShipperPhone { get; set; }
        public string ShipperCompany { get; set; }
        public string ShipperName { get; set; }
        public string ShipperAddress1 { get; set; }
        public string ShipperAddress2 { get; set; }
        public string ShipperCity { get; set; }
        public string ShipperStPv { get; set; }
        public string ShipperCountry { get; set; }
        public string ShipperPostal { get; set; }
        public string Broker { get; set; }
        public string BrokerPhone { get; set; }
        public string BrokerCity { get; set; }
        public string BrokerCountry { get; set; }
        public string CustomsIdrNbr { get; set; }
        public string Svc { get; set; }
        public string BillTc { get; set; }
        public string BillDt { get; set; }
        public string TotalPackages { get; set; }
        public string TotalWeight { get; set; }
        public string Currency { get; set; }
        public string CustomsValue { get; set; }
        public string FreightAmmountUsd { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}
