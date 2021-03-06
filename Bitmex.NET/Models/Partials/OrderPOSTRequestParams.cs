﻿using System;

namespace Bitmex.NET.Models
{
    public partial class OrderPOSTRequestParams
    {
        public static OrderPOSTRequestParams ClosePositionByMarket(string symbol)
        {
            return new OrderPOSTRequestParams
            {
                Symbol = symbol,
                ExecInst = "Close"
            };
        }
        public static OrderPOSTRequestParams ClosePositionByLimit(string symbol, decimal price)
        {
            return new OrderPOSTRequestParams
            {
                Symbol = symbol,
                ExecInst = "Close",
                Price = price
            };
        }

        public static OrderPOSTRequestParams CreateSimpleMarket(string symbol, int quantity, OrderSide side)
        {
            return new OrderPOSTRequestParams
            {
                Symbol = symbol,
                Side = Enum.GetName(typeof(OrderSide), side),
                OrderQty = quantity,
                OrdType = Enum.GetName(typeof(OrderType), OrderType.Market),
            };
        }

        public static OrderPOSTRequestParams CreateSimpleLimit(string symbol, int quantity, decimal price, OrderSide side)
        {
            return new OrderPOSTRequestParams
            {
                Symbol = symbol,
                Side = Enum.GetName(typeof(OrderSide), side),
                OrderQty = quantity,
                OrdType = Enum.GetName(typeof(OrderType), OrderType.Limit),
                DisplayQty = quantity,
                Price = price,
                ExecInst = "ParticipateDoNotInitiate",
            };
        }

        /// <summary>
        /// Be aware that bitmex takes fee for hiden limit orders
        /// </summary>
        public static OrderPOSTRequestParams CreateSimpleHidenLimit(string symbol, int quantity, decimal price, OrderSide side)
        {
            return new OrderPOSTRequestParams
            {
                Symbol = symbol,
                Side = Enum.GetName(typeof(OrderSide), side),
                OrderQty = quantity,
                OrdType = Enum.GetName(typeof(OrderType), OrderType.Limit),
                DisplayQty = 0,
                Price = price,
                ExecInst = "ParticipateDoNotInitiate",
            };
        }

        public static OrderPOSTRequestParams CreateMarketStopOrder(string symbol, int quantity, decimal stopPrice, OrderSide side)
        {
            return new OrderPOSTRequestParams
            {
                Symbol = symbol,
                Side = Enum.GetName(typeof(OrderSide), side),
                OrderQty = quantity,
                OrdType = Enum.GetName(typeof(OrderType), OrderType.Stop),
                StopPx = stopPrice,
                ExecInst = "ReduceOnly,LastPrice",
            };
        }

        public static OrderPOSTRequestParams CreateLimitStopOrder(string symbol, int quantity, decimal stopPrice, decimal price, OrderSide side)
        {
            return new OrderPOSTRequestParams
            {
                Symbol = symbol,
                Side = Enum.GetName(typeof(OrderSide), side),
                OrderQty = quantity,
                OrdType = Enum.GetName(typeof(OrderType), OrderType.StopLimit),
                StopPx = stopPrice,
                //Price = price,
                ExecInst = "ReduceOnly,LastPrice",
            };
        }

        public static OrderPOSTRequestParams CreateTakeProfitOrder(string symbol, int quantity, decimal stopPrice, OrderSide side)
        {
            return new OrderPOSTRequestParams
            {
                Symbol = symbol,
                Side = Enum.GetName(typeof(OrderSide), side),
                OrderQty = quantity,
                OrdType = Enum.GetName(typeof(OrderType), OrderType.MarketIfTouched),
                StopPx = stopPrice,
                ExecInst = "ReduceOnly,LastPrice",
            };
        }

        public static OrderPOSTRequestParams CreateTrailingStopOrder(string symbol, int quantity, decimal pegOffsetValue, OrderSide side)
        {
            return new OrderPOSTRequestParams
            {
                Symbol = symbol,
                OrderQty = quantity,
                OrdType = Enum.GetName(typeof(OrderType), OrderType.MarketIfTouched),
                PegOffsetValue = side == OrderSide.Buy ? pegOffsetValue : -pegOffsetValue,
                ExecInst = "ReduceOnly,LastPrice",
            };
        }
    }
}
