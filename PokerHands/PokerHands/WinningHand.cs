namespace PokerHands
{
    public class WinningHand
    {
        public WinningHand(HandValue val, Winner winner)
        {
            Hand = val;
            Winner = winner;
        }

        private WinningHand()
        {

        }

        public static WinningHand Draw = new WinningHand();
        public HandValue Hand { get; }
        public Winner Winner { get; }
    }

    public enum Winner
    {
        Player1,
        Player2,
        Draw
    }

}