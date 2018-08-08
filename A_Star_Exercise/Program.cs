using System;
using System.Collections.Generic;
using System.Drawing;

namespace A_Star_Exercise
{
    public enum CompassDirections
    {
        NotSet = 0,
        North = 1,//up
        NorthEast = 2,//up right
        East = 3,
        SouthEast = 4,
        South = 5,
        SouthWeat = 6,
        West = 7,
        NorthWest = 8
    }
    public interface ICostGetter
    {
        int GetCost(Point currentNodeLocation, CompassDirections moveDirection);
    }

    public class SimpleCostGetter : ICostGetter
    {
        public int GetCost(Point currentNodeLocation,CompassDirections moveDirection)
        {
            if(moveDirection == CompassDirections.NotSet)
            {
                return 0;
            }
            if(moveDirection == CompassDirections.East || moveDirection == CompassDirections.West
                || moveDirection == CompassDirections.South || moveDirection == CompassDirections.North)
            {
                return 10;
            }
            return 14;
        }
    }

    public class AStarNode
    {
        #region Constructor
        public AStarNode(Point loc,AStarNode previous,int _costG,int _costH)
        {   
            this.location = loc;
            this.previousNode = previous;
            this.costG = _costG;
            this.costH = _costH;
        }
        #endregion
        //======================================
        #region Location
        private Point location = new Point(0,0);
        public Point Location
        {
            get { return location;}
        }
        #endregion
        //======================================
        #region Previous Node
        private AStarNode previousNode = null;
        public AStarNode PreviousNode
        {
            get{ return previousNode;}
        }
        #endregion
        //=======================================
        #region CostF
        //<summary>
        //CostF 从起点导航经过本节点然后再到目的节点的估算总代价
        //</summary>
        public int CostF
        {
            get
            {
                return this.CostG + this.CostH;
            }
        }
        #endregion
        //=======================================
        #region CostG
        //<summary>
        //CostG 从起点导航到本节点的代价
        //</summary>
        private int costG;
        public int CostG
        {
            get{return costG;}
        }
        #endregion
        //=======================================
        #region CostH
        //<summary>
        //CostH 使用启发式方法估算从本节点到目的节点的代价
        //</smmary>
        private int costH;
        public int CostH
        {
            get{return costH;}
        }
        #endregion
        //=======================================
        #region ResetPreviousNode
        //<summary>
        //ResetPreviousNode 当从起点到达本节点有更优的路径时，调用该方法采用更优的路径
        //</summary>
        public void ResetPreviosNode(AStarNode previous, int _costG)
        {
            this.previousNode = previous;
            this.costG = _costG;
        }
        #endregion

        public override string ToString()
        {
            return this.location.ToString();
        }

    }
    public class RoutePlanData
    {
        private Rectangle cellMap;
        //<summary>
        //CellMap 地图的矩形大小.经过单元格标准处理
        //</summary>
        public Rectangle CellMap
        {
            get { return cellMap;}
        }
        private IList<AStarNode> closedList = new List<AStarNode>();
        public IList<AStarNode> ClosedList
        {
            get{return closedList;}
        }

        private IList<AStarNode> openedList = new List<AStarNode>();
        public IList<AStarNode> OpenedList
        {
            get{return openedList;}
        }
        private Point destination;
        public Point Destination
        {
            get {return destination;}
        }

        public RoutePlanData(Rectangle map,Point _destination)
        {
            this.cellMap = map;
            this.destination = _destination;
        }

        public class AStarRoutePlanner
        {
            private int lineCount = 10;
            private int columnCount = 10;
            private ICostGetter costGetter = new SimpleCostGetter();
            private bool[][] obstacles = null;

            public AStarRoutePlanner() :this(10,10,new SimpleCostGetter())
            {

            }
            public AStarRoutePlanner(int _lineCount, int _columnCount, ICostGetter _costGetter)
            {
                this.lineCount = _lineCount;
                this.columnCount = _columnCount;
                this.costGetter = _costGetter;

                this.InitializeObstacles();
            }
            public void InitializeObstacles()
            {
                this.obstacles = new bool[this.columnCount][];
                for(int i = 0; i<this.columnCount;i++)
                {
                    this.obstacles[i] = new bool[this.lineCount];
                }

                for(int i = 0; i<this.columnCount;i++)
                {
                    for(int j = 0;j<this.lineCount;j++)
                    {
                        this.obstacles[i][j] = false;
                    }
                }
            }

            public void Initialize(IList<Point> obstaclePoints)
            {
                if(obstacles != null)
                {
                    foreach(Point pt in obstaclePoints)
                    {
                        this.obstacles[pt.X][pt.Y] = true;
                    }
                }
            } 

            public IList<Point> Plan(Point start,Point destination)
            {
                Rectangle map = new Rectangle(0,0,this.columnCount,this.lineCount);
                if((!map.Contains(start))||(!map.Contains(destination)))
                {
                    throw new Exception("StartPoint or Destination not in the current map!");
                }
                RoutePlanData routePlanData = new RoutePlanData(map,destination);

                AStarNode startNode = new AStarNode(start,null,0,0);
                routePlanData.OpenedList.Add(startNode);

                AStarNode currentNode = startNode;

                return DoPlan(routePlanData,currentNode);
            }

            private IList<Point> DoPlan(RoutePlanData routePlanData,AStarNode currentNode)
            {
                //Console.WriteLine(currentNode.ToString());
                IList<CompassDirections> allCompassDirections = CompassDirectionsHelper.GetAllCompassDirections();
                foreach(CompassDirections direction in allCompassDirections)
                {
                    Point nextCell = GeometryHelper.GetAdjacentPoint(currentNode.Location,direction);
                    if(!routePlanData.CellMap.Contains(nextCell))
                    {
                        continue;
                    }
                    if(this.obstacles[nextCell.X][nextCell.Y])
                    {
                        continue;
                    }
                    int costG = this.costGetter.GetCost(currentNode.Location, direction);
                    int costH = Math.Abs(nextCell.X - routePlanData.Destination.X) + Math.Abs(nextCell.Y - routePlanData.Destination.Y);
                    if(costH == 0)
                    {
                        IList<Point> route = new List<Point>();
                        route.Add(routePlanData.Destination);
                        route.Insert(0,currentNode.Location);
                        AStarNode tempNode = currentNode;
                        while(tempNode.PreviousNode != null)
                        {
                            route.Insert(0,tempNode.PreviousNode.Location);
                            tempNode = tempNode.PreviousNode;
                        }
                        return route;
                    }
                    AStarNode existNode = this.GetNodeOnLocation(nextCell, routePlanData);
                    if(existNode != null)
                    {
                        if(existNode.CostG > costG)
                        {
                            existNode.ResetPreviosNode(currentNode,costG);
                        }
                    }
                    else
                    {
                        AStarNode newNode = new AStarNode(nextCell, currentNode,costG,costH);
                        routePlanData.OpenedList.Add(newNode);
                    }
                }
                routePlanData.OpenedList.Remove(currentNode);
                routePlanData.ClosedList.Add(currentNode);

                AStarNode minCostNode = this.GetMinCostNode(routePlanData.OpenedList);
                if(minCostNode == null)
                {
                    return null;
                }
                return this.DoPlan(routePlanData, minCostNode);
            }
            private AStarNode GetNodeOnLocation(Point location, RoutePlanData routePlanData)
            {
                foreach(AStarNode temp in routePlanData.OpenedList)
                {
                    if(temp.Location == location)
                    {
                        return temp;
                    }
                }

                foreach(AStarNode temp in routePlanData.ClosedList)
                {
                    if(temp.Location == location)
                    {
                        return temp;
                    }
                }
                return null;
            }
            private AStarNode GetMinCostNode(IList<AStarNode> openedList)
            {
                if(openedList.Count == 0)
                {
                    return null;
                }
                AStarNode target = openedList[0];
                foreach(AStarNode temp in openedList)
                {
                    if(temp.CostF < target.CostF)
                    {
                        target = temp;
                    }
                }
                return target;
            } 
            public static void Main(string[] args)
            {
                AStarRoutePlanner aStarRoutePlanner = new AStarRoutePlanner();
                IList<Point> obstaclePoints = new List<Point>();
                obstaclePoints.Add(new Point(2,4));
                obstaclePoints.Add(new Point(3,4));
                obstaclePoints.Add(new Point(4,4));
                obstaclePoints.Add(new Point(5,4));
                obstaclePoints.Add(new Point(6,4));
                aStarRoutePlanner.Initialize(obstaclePoints);

                IList<Point> route = aStarRoutePlanner.Plan(new Point(3,3), new Point(4,6));
                foreach(Point tmp in route)
                {
                    Console.WriteLine("x="+tmp.X+",Y="+tmp.Y);
                } 
            }
        }
    }






    public static class CompassDirectionsHelper
    {
        private static IList<CompassDirections> AllCompassDirections = new List<CompassDirections>();
        static CompassDirectionsHelper()
        {
            CompassDirectionsHelper.AllCompassDirections.Add(CompassDirections.East);
            CompassDirectionsHelper.AllCompassDirections.Add(CompassDirections.West);
            CompassDirectionsHelper.AllCompassDirections.Add(CompassDirections.South);
            CompassDirectionsHelper.AllCompassDirections.Add(CompassDirections.North);
            CompassDirectionsHelper.AllCompassDirections.Add(CompassDirections.SouthEast);
            CompassDirectionsHelper.AllCompassDirections.Add(CompassDirections.SouthWeat);
            CompassDirectionsHelper.AllCompassDirections.Add(CompassDirections.NorthEast);
            CompassDirectionsHelper.AllCompassDirections.Add(CompassDirections.NorthWest);
        }

        public static IList<CompassDirections> GetAllCompassDirections()
        {
            return CompassDirectionsHelper.AllCompassDirections;
        }
    }

    public static class GeometryHelper
    {
        public static Point GetAdjacentPoint(Point current,CompassDirections direction)
        {
            switch(direction)
            {
                case CompassDirections.North:
                {
                    return new Point(current.X,current.Y-1);
                }
                case CompassDirections.South:
                {
                    return new Point(current.X,current.Y+1);
                }
                case CompassDirections.East:
                {
                    return new Point(current.X+1,current.Y);
                }
                case CompassDirections.West:
                {
                    return new Point(current.X-1,current.Y);
                }
                case CompassDirections.NorthEast:
                {
                    return new Point(current.X+1,current.Y-1);
                }
                case CompassDirections.NorthWest:
                {
                    return new Point(current.X-1,current.Y-1);
                }
                case CompassDirections.SouthEast:
                {
                    return new Point(current.X+1,current.Y+1);
                }
                case CompassDirections.SouthWeat:
                {
                    return new Point(current.X-1,current.Y+1);
                }
                default:
                {
                    return current;
                }

            }
        }
    }

    
}
