using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

class Exercise18{
    int cardCount;
    public void playBlackJack(){
        Console.WriteLine("Welcome to the BlackJack game!");
        gameMenu();
    }

    public void gameMenu(){
        while(true){
            Console.WriteLine("Choose opponent: \n1 - You vs Dealer\n2 - IA vs Dealer");
            string? choice = Console.ReadLine();
            if(!string.IsNullOrEmpty(choice)){
                switch(choice){
                    case "1":
                        initializeUserVsDealer();  
                        break;
                    case "2": 
                        initializeIaVsDealer();
                        break;
                }
            }
            else{
                Console.WriteLine("Invalid input, retry.");
            }
        }
    }

    public void initializeIaVsDealer(){
        int cardCount = 0;

        List<Card> deck = initializeDeck();
        List<Card> iaHand = new List<Card>();
        List<Card> dealerHand = new List<Card>();

        int? IaTotal;
        int? dealerTotal;

        iaHand.Add(drawCard(deck));
        iaHand.Add(drawCard(deck));
        dealerHand.Add(drawCard(deck));
        dealerHand.Add(drawCard(deck));

        foreach (Card card1 in iaHand.Concat(dealerHand))
        {
            cardCount = cardsCounter(cardCount, card1);
        }
        Console.WriteLine($"Dealer shows: {dealerHand[0].Value} of {dealerHand[0].Suit}");
        IaTotal = playTurn("IA",iaHand,deck);
        if(IaTotal > 21){
            Console.WriteLine("BUSTED!");
            return;
        }

        // Dealer Turn

        dealerTotal = playDeealerTurn(dealerHand,deck);

        // Winner
        if(dealerTotal > IaTotal && dealerTotal < 22){
            Console.WriteLine("Dealer wins!");
        }
        else if(IaTotal > dealerTotal && IaTotal < 22){
            Console.WriteLine("IA wins!");
        }
        else if(IaTotal == dealerTotal){
            Console.WriteLine("Tie!");
        }

    }

    public void initializeUserVsDealer(){
        List<Card> deck = initializeDeck();

        List<Card> playerHand = new List<Card>();
        List<Card> dealerHand = new List<Card>();

        int? playerTotal;
        int? dealerTotal;

        playerHand.Add(drawCard(deck));
        playerHand.Add(drawCard(deck));
        dealerHand.Add(drawCard(deck));
        dealerHand.Add(drawCard(deck));
        
        // User turn
        Console.WriteLine($"Dealer shows: {dealerHand[0].Value} of {dealerHand[0].Suit}");
        playerTotal = playTurn("User",playerHand, deck);
        if(playerTotal > 21){
            Console.WriteLine("BUSTED!");
            return;
        }

        // Dealer Turn

        dealerTotal = playDeealerTurn(dealerHand,deck);

        // Winner
        if(dealerTotal > playerTotal && dealerTotal < 22){
            Console.WriteLine("Dealer wins!");
        }
        else if(playerTotal > dealerTotal && playerTotal < 22){
            Console.WriteLine("You win!");
        }
        else if(playerTotal == dealerTotal){
            Console.WriteLine("Tie!");
        }
    }

    public int? playTurn(string player, List<Card> hand, List<Card> deck){
        int? totalSum = SumCards(hand);
        if (player == "IA"){
            // High count means deck has high-value cards, IA is more aggressive
            if (cardCount > 5) {
                if (totalSum <= 16) {
                    Card card = drawCard(deck);
                    hand.Add(card);
                    Console.WriteLine($"IA draws a card: {card.Value} of {card.Suit}");
                    totalSum = SumCards(hand);
                    cardCount = cardsCounter(cardCount, card);
                    if(totalSum > 21){
                        return totalSum;
                    }
                }
            }
            // Low count means deck has low-value cards, IA is more conservative
            else if (cardCount < 0) {
                if (totalSum >= 14) {
                    Console.WriteLine("IA chooses to stand.");
                    return totalSum;
                } else {
                    Card card = drawCard(deck);
                    hand.Add(card);
                    Console.WriteLine($"IA draws a card: {card.Value} of {card.Suit}");
                    totalSum = SumCards(hand);
                    cardCount = cardsCounter(cardCount, card);
                }
            }
            // Neutral or low positive count, standard logic
            else {
                if (totalSum >= 17) {
                    Console.WriteLine("IA chooses to stand.");
                    return totalSum;
                } else {
                    Card card = drawCard(deck);
                    hand.Add(card);
                    Console.WriteLine($"IA draws a card: {card.Value} of {card.Suit}");
                    totalSum = SumCards(hand);
                    cardCount = cardsCounter(cardCount, card);
                }
            }
        }
        else{
            // User Turn
            while(totalSum <= 21){
                Console.WriteLine($"{player} hand: " + DisplayHand(hand));
                Console.WriteLine("Total: "+totalSum);
                string? choice = hitOrStand();
                if(choice.Equals("H")){
                    Card card = drawCard(deck);
                    hand.Add(card);
                    Console.WriteLine("Card drawn: " + $"{card.Value} of {card.Suit}");
                    totalSum = SumCards(hand);
                    if(totalSum > 21){
                        return totalSum;
                    }
                }
                else if(choice.Equals("S")){
                    break;
                } 
            }
        }
        return totalSum;
    }

    public int playDeealerTurn(List<Card> hand, List<Card> deck){
        int dealerTotal = SumCards(hand);
        Console.WriteLine("Dealer reveals his hidden card.");
        Console.WriteLine("Dealer hand: "+DisplayHand(hand));
        Card card = new Card();

        while(dealerTotal < 17){
            card = drawCard(deck);
            hand.Add(card);
            Console.WriteLine("Card drawn: " + $"{card.Value} of {card.Suit}");
            dealerTotal = SumCards(hand);
        }

        return dealerTotal;

    }
    /**
        Cheathing system: Hi-Lo counting system. In this system, cards with values 2-6 are worth +1 point, 7-9 are worth 0 points, and 10, Jack, Queen, King, and Ace are worth -1 point.
    **/
    public int cardsCounter(int cardCount, Card card){
        if (int.TryParse(card.Value, out int cardValue))
        {
            if (cardValue >= 2 && cardValue <= 6)
            {
                return cardCount + 1;
            }
            else if (cardValue >= 10 || card.Value == "Jack" || card.Value == "Queen" || card.Value == "King" || card.Value == "Ace")
            {
                return cardCount - 1;
            }
        }
        return cardCount;
    }

    public int SumCards(List<Card> hand){
        int totalValue = 0;
        int aceCount = 0;

        foreach (var card in hand)
        {
            if (int.TryParse(card.Value, out int cardValue))
            {
                totalValue += cardValue;
            }
            else if (card.Value == "Jack" || card.Value == "Queen" || card.Value == "King")
            {
                totalValue += 10;
            }
            else if (card.Value == "Ace")
            {
                aceCount++;
                totalValue += 11;
            }
        }

        while (totalValue > 21 && aceCount > 0)
        {
            totalValue -= 10;
            aceCount--;
        }

        return totalValue;
    }

    public string hitOrStand(){
        while(true){
            Console.WriteLine("Hit or stand? Type H for hit and S for stand");
            string? choice = Console.ReadLine();
            if(string.IsNullOrEmpty(choice)){
               Console.WriteLine("Incorrect input. retype!"); 
            }
            else{
                if(choice.Equals("H")){
                    Console.WriteLine("U choose to hit");
                    return "H";
                }
                else if(choice.Equals("S")){
                    Console.WriteLine("U choose to stand");
                    return "S";
                }else{
                    Console.WriteLine("Incorrect input. retype!"); 
                }
            }
        }
    }

    public Card drawCard(List<Card> deck){
        Random rand = new Random();
        int randomIndex = rand.Next(deck.Count);
        Card drawnCard = deck[randomIndex];
        deck.RemoveAt(randomIndex);
        return drawnCard;
    }

    public string DisplayHand(List<Card> hand)
    {
        return string.Join(", ", hand.Select(card => $"{card.Value} of {card.Suit}"));
    }


    public List<Card> initializeDeck(){
        List<Card> deck = new List<Card>();
        
        string[] suits = { "Hearts", "Clubs", "Diamonds", "Spades" };
        string[] values = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };

        foreach (var suit in suits)
        {
            foreach (var value in values)
            {
                deck.Add(new Card() { Suit = suit, Value = value });
            }
        }
        return deck;
    }
}

class Card{
    public string? Suit { get; set; }
    public string? Value { get; set; }
}