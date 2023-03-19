using NLog;
using SystemModule.Data;
using SystemModule.Packets.ServerPackets;

namespace GameSrv.World.Managers
{
    public class MarketConst
    {
        public const int MAKET_ITEMCOUNT_PER_PAGE = 10;
        public const int MAKET_MAX_PAGE = 15;
        public const int MAKET_MAX_ITEM_COUNT = MAKET_ITEMCOUNT_PER_PAGE * MAKET_MAX_PAGE;
        public const int MARKET_CHARGE_MONEY = 1000;
        public const int MARKET_ALLOW_LEVEL = 1;// 1 饭骇 捞惑父 等促.
        public const int MARKET_COMMISION = 10;// 1000 盒狼 1 窜困肺 历厘
        public const int MARKET_MAX_TRUST_MONEY = 50000000;//弥措陛咀
        public const int MARKET_MAX_SELL_COUNT = 5;// 弥措 割俺鳖瘤 登唱.
        public const int MAKET_STATE_EMPTY = 0;
        public const int MAKET_STATE_LOADING = 1;
        public const int MAKET_STATE_LOADED = 2;
    }

    public class MarketManager
    {
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// 0 = Empty , 1 = Loading 2 = Full
        /// </summary>
        private int FState;
        protected int FMaxPage;
        private int FCurrPage;
        private int FLoadedPage;
        private int FSelectedIndex;
        private int FUserMode;
        private int FItemType;
        private IList<MarketItem> Items;
        private MarKetReqInfo ReqInfo;

        public MarketManager()
        {
            Items = new List<MarketItem>();
            FSelectedIndex = -1;
            FState = MarketConst.MAKET_STATE_EMPTY;
            ReqInfo = new MarKetReqInfo();
            ReqInfo.UserName = string.Empty;
            ReqInfo.MarketName = string.Empty;
            ReqInfo.SearchWho = string.Empty;
            ReqInfo.SearchItem = string.Empty;
            ReqInfo.ItemType = 0;
            ReqInfo.ItemSet = 0;
            ReqInfo.UserMode = 0;
        }

        protected void Load()
        {
            if (IsEmpty && FState == MarketConst.MAKET_STATE_EMPTY)
            {
                OnMsgReadData();
            }
        }

        protected void ReLoad()
        {
            if (!IsEmpty) RemoveAll();
            Load();
            _logger.Info("重载拍卖行物品列表...");
        }

        public void RemoveAll()
        {
            Items.Clear();
            _logger.Info("清空拍卖行物品列表...");
        }

        protected void Add(MarketItem marketItem)
        {
            if ((Items != null) && (marketItem != null))
            {
                //Items.Add(marketItem);
                OnMsgWriteData(marketItem);
            }
            if (Items.Count % MarketConst.MAKET_ITEMCOUNT_PER_PAGE == 0)
            {
                FLoadedPage = (Items.Count / MarketConst.MAKET_ITEMCOUNT_PER_PAGE);
            }
            else
            {
                FLoadedPage = (Items.Count / MarketConst.MAKET_ITEMCOUNT_PER_PAGE) + 1;
            }
        }

        protected void Delete(int index)
        {

        }

        protected void Clear()
        {
            RemoveAll();
            FSelectedIndex = -1;
            FState = MarketConst.MAKET_STATE_EMPTY;
        }

        public MarketItem GetItem(int index, ref bool selected)
        {
            var marketItem = GetItem(index);
            selected = false;
            if (marketItem != null)
            {
                selected = index == FSelectedIndex;
            }
            return marketItem;
        }

        public MarketItem GetItem(int index)
        {
            if (CheckIndex(index))
            {
                return Items[index];
            }
            return null;
        }

        public bool IsExistIndex(int index, ref int money)
        {
            var result = false;
            money = 0;
            for (int i = 0; i < Items.Count; i++)
            {
                var pInfo = Items[i];
                if (pInfo != null)
                {
                    if (pInfo.Index == index)
                    {
                        result = true;
                        money = pInfo.SellPrice;
                        break;
                    }
                }
            }
            return result;
        }

        public bool IsMyItem(int index, string charName)
        {
            var result = false;
            if (string.IsNullOrEmpty(charName))
            {
                return false;
            }
            for (int i = 0; i < Items.Count; i++)
            {
                var pInfo = Items[i];
                if (pInfo != null)
                {
                    if (pInfo.Index == index && string.Compare(pInfo.SellWho, charName, StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        result = true;
                        break;
                    }
                }
            }
            return result;
        }

        public bool Select(int index)
        {
            var result = false;
            if (CheckIndex(index))
            {
                FSelectedIndex = index;
                result = true;
            }
            return result;
        }

        private bool CheckIndex(int index)
        {
            return index >= 0 && index < Items.Count;
        }

        public bool IsEmpty => Items.Count > 0;

        public int Count => Items.Count;

        public int PageCount()
        {
            if (Items.Count % MarketConst.MAKET_ITEMCOUNT_PER_PAGE == 0)
            {
                return Items.Count / MarketConst.MAKET_ITEMCOUNT_PER_PAGE;
            }
            else
            {
                return (Items.Count / MarketConst.MAKET_ITEMCOUNT_PER_PAGE) + 1;
            }
        }

        public void OnMsgReadData(MarketDataMessage serverRequestData = default)
        {
            //todo 收到DBSrv最新的拍卖行数据
            //循环新数据和历史数据进行对比，删除不存在和新增，避免同时客户端正在操作
            FState = 0;
            Items = serverRequestData.List;
            FMaxPage = (int)Math.Ceiling(serverRequestData.TotalCount / (double)MarketConst.MAKET_ITEMCOUNT_PER_PAGE);
            _logger.Info("收到拍卖行数据同步消息，共{0}条数据", serverRequestData.TotalCount);
        }

        private void OnMsgWriteData(MarketItem marketItem)
        {
            //新增拍卖行数据实时同步到DBSrv,避免数据不一致的情况,并由DBSrv定时广播给所有GameSrv
            var request = new ServerRequestMessage(Messages.DB_SAVEMARKET, 0, 0, 0, 0); 
            var requestData = new MarketSaveDataItem() { Item = marketItem };
            M2Share.MarketService.SendRequest(1, request, requestData);
            _logger.Info("发送拍卖行数据同步消息，物品名称:{0} 物品编号:{1} 售卖人:{2}", marketItem.Item.Item.Name, marketItem.Item.MakeIndex, marketItem.SellWho);
        }

        public int UserMode { get => FUserMode; set { FUserMode = value; } }
        public int ItemType { get => FItemType; set { FItemType = value; } }
        public int LodedPage => FLoadedPage;
        public int CurrPage { get => FCurrPage; set { FCurrPage = value; } }
    }
}