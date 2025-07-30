using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace TestWindowsFormsApp_.NET_Framework_
{
    internal abstract class Tile
    {
        public int X { get; set; }
        public int Y { get; set; }

        public abstract Image GetImage();

        public virtual void CopyData(Tile target)
        {
            target.X = this.X;
            target.Y = this.Y;
        }
        public abstract Tile CreateSameType();

        public bool isVictoryTile = false;
        public Tile(int Xarg, int Yarg)
        {
            X = Xarg;
            Y = Yarg;
        }
        public Tile()
        {
            X = 0;
            Y = 0;
        }
    }

    internal class Head : Tile
    {
        public override Tile CreateSameType()
        {
            return new Head();
        }
        public override Image GetImage()
        {
            return Data.HeadImage;
        }
        public Head(int Xarg, int Yarg) : base(Xarg, Yarg)
        {

        }
        public Head() : base()
        {

        }
    }
    internal class Body : Tile
    {
        public override Tile CreateSameType()
        {
            return new Body();
        }
        public override Image GetImage()
        {
            return Data.BodyImage;
        }
        public Body(int Xarg, int Yarg) : base(Xarg, Yarg)
        {

        }
        public Body() : base()
        {

        }
    }
    internal class Wall : Tile
    {
        public override Tile CreateSameType()
        {
            return new Wall();
        }
        public override Image GetImage()
        {
            return Data.WallImage;
        }
        public Wall(int Xarg, int Yarg) : base(Xarg, Yarg)
        {

        }
        public Wall() : base()
        {

        }
    }


    internal class Empty : Tile
    {
        public override Tile CreateSameType()
        {
            return new Empty();
        }
        public override Image GetImage()
        {
            return Data.EmptyImage;
        }
        public Empty(int Xarg, int Yarg) : base(Xarg, Yarg)
        {

        }
        public Empty() : base()
        {

        }
    }
    internal class Edible : Tile
    {
        public override Tile CreateSameType()
        {
            return new Edible();
        }

        public override void CopyData(Tile target)
        {
            base.CopyData(target);
            Edible e = target as Edible;
            e.GrowthValue = this.GrowthValue;
        }

        public int GrowthValue { get; set; }
        public override Image GetImage()
        {
            return Data.FoodImage;
        }
        public Edible(int Xarg, int Yarg, int GrowthValuearg) : base(Xarg, Yarg)
        {
            this.GrowthValue = GrowthValuearg;
        }
        public Edible() : base()
        {
            this.GrowthValue = 1;
        }
    }

    internal abstract class Movable : Tile
    {
        public abstract override Tile CreateSameType();
        public abstract override Image GetImage();
        public Movable(int Xarg, int Yarg) : base(Xarg, Yarg)
        {

        }
        public Movable() : base()
        {

        }
    }
    internal class UnMuncher : Movable
    {
        public override Tile CreateSameType()
        {
            return new UnMuncher();
        }
        public override Image GetImage()
        {
            return Data.UnMuncherImage;
        }
        public UnMuncher(int Xarg, int Yarg) : base(Xarg, Yarg)
        {

        }
        public UnMuncher() : base()
        {

        }
    }
    internal class Muncher : Movable
    {
        public override Tile CreateSameType()
        {
            return new Muncher();
        }
        public override Image GetImage()
        {
            return Data.MuncherImage;
        }
        
        public Muncher(int Xarg, int Yarg) : base(Xarg, Yarg)
        {

        }
        public Muncher() : base()
        {

        }
    }
    internal class Mover : Movable
    {
        public int DeltaX = 0;
        public int DeltaY = 0;
        public override Tile CreateSameType()
        {
            return new Mover(DeltaX, DeltaY);
        }
        public override Image GetImage()
        {
            return Data.FoodImage;
        }
        public Mover(int deltaX, int deltaY) : base()
        {
            DeltaX = deltaX;
            DeltaY = deltaY;
        }
        public Mover(int xargs, int yargs, int deltaX, int deltaY) : base(xargs, yargs)
        {
            DeltaX = deltaX;
            DeltaY = deltaY;
        }
    }
    internal abstract class SecondaryTile : Tile
    {
        public abstract override Tile CreateSameType();

        public abstract override Image GetImage();
        
        public SecondaryTile() : base()
        {

        }
        public SecondaryTile(int Xarg, int Yarg) : base(Xarg, Yarg)
        {

        }
    }

    internal class VictoryTile : Tile
    {
        public override Tile CreateSameType()
        {
            return new VictoryTile();
        }
        public override Image GetImage()
        {
            return Data.YesVicImage;
        }
        public VictoryTile() : base()
        {

        }
        public VictoryTile(int Xarg, int Yarg) : base(Xarg, Yarg)
        {

        }
    }
}
