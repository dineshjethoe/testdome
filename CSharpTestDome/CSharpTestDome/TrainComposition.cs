/*
    A TrainComposition is built by attaching and detaching wagons from the left and the right sides, efficiently with respect to time used.

    For example, if we start by attaching wagon 7 from the left followed by attaching wagon 13, 
    3 again from the left, 
    we get a composition of two wagons (13 and 7 from left to right). 
    Now the first wagon that can be detached from the right is 7 and the first that can be detached from the left is 13.

    Implement a TrainComposition that models this problem. 

    Tip: practice Linked List and Doubly Linked List
*/

using System;

public class TrainComposition
{
    public class TrainNode
    {
        public int Value;
        public TrainNode LeftTrain;
        public TrainNode RightTrain;

        public TrainNode(int value)
        {
            this.Value = value;
            this.LeftTrain = null;
            this.RightTrain = null;
        }

        public void SetRightTrain(TrainNode right)
        {
            this.RightTrain = right;
        }

        public void SetLeftTrain(TrainNode left)
        {
            this.LeftTrain = left;
        }
    }

    private TrainNode leftMost;
    private TrainNode rightMost;

    public TrainComposition()
    {
        leftMost = null;
        rightMost = null;
    }

    public void AttachWagonFromLeft(int wagonId)
    {
        var tmp = new TrainNode(wagonId);
        if (leftMost != null)
        {
            // Trains in composition
            leftMost.SetLeftTrain(tmp);
            tmp.SetRightTrain(leftMost);
            leftMost = tmp;
        }
        else
        {
            leftMost = tmp;
            rightMost = tmp;
        }
    }

    public void AttachWagonFromRight(int wagonId)
    {
        var tmp = new TrainNode(wagonId);
        if (rightMost != null)
        {
            // Trains in composition
            rightMost.SetRightTrain(tmp);
            tmp.SetLeftTrain(rightMost);
            rightMost = tmp;
        }
        else
        {
            leftMost = tmp;
            rightMost = tmp;
        }
    }

    public int DetachWagonFromLeft()
    {
        TrainNode tmp;
        if (leftMost != null)
        {
            tmp = leftMost;
            leftMost = leftMost.RightTrain;
            var tmpValue = tmp.Value;
            return tmpValue;
        }
        else
        {
            return 0;
        }
    }

    public int DetachWagonFromRight()
    {
        TrainNode tmp;
        if (rightMost != null)
        {
            tmp = rightMost;
            rightMost = rightMost.LeftTrain;
            var tmpValue = tmp.Value;
            return tmpValue;
        }
        else
        {
            return 0;
        }
    }

    public static void Main(string[] args)
    {
        var tree = new TrainComposition();
        tree.AttachWagonFromLeft(7);
        tree.AttachWagonFromLeft(13);
        Console.WriteLine(tree.DetachWagonFromRight()); // 7 
        Console.WriteLine(tree.DetachWagonFromLeft()); // 13
    }
}