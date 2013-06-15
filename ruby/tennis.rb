
class TennisScorer

  SCORE_NAMES =  {
    0 => "Love",
    1 => "Fifteen",
    2 => "Thirty",
    3 => "Forty",
  }

  def initialize(player1Name, player2Name, p1points, p2points)
   @player1Name = player1Name
   @player2Name = player2Name
   @p1points = p1points
   @p2points = p2points
 end

# options: extract bodies, extract conditions with name, extract maps to constants
 def score
   result = ""
   tempScore=0
   if same_score?
     if at_least_4_points?
       result = "Deuce"
     else
       result = SCORE_NAMES[@p1points] + "-All"
     end
   elsif at_least_4_points?
     minusResult = @p1points-@p2points
     if (minusResult==1)
       result ="Advantage " + @player1Name
     elsif (minusResult ==-1)
       result ="Advantage " + @player2Name
     elsif (minusResult>=2)
       result = "Win for " + @player1Name
     else
       result ="Win for " + @player2Name
     end
   else
     (1...3).each do |i|
       if (i==1)
         tempScore = @p1points
       else
         result+="-"
         tempScore = @p2points
       end
       result += SCORE_NAMES[tempScore]
     end
   end
   result
 end

  private

  def name_same_score

  end

  def same_score?
    @p1points==@p2points
  end

  def at_least_4_points?
    @p1points>=4 or @p2points>=4
  end

end

class TennisGame

  def initialize(player1Name, player2Name)
    @player1Name = player1Name
    @player2Name = player2Name
    @p1points = 0
    @p2points = 0
  end

  def won_point(playerName)
    if playerName == @player1Name
      @p1points += 1
    else
      @p2points += 1
    end
  end

  # move method to another class
  def score
    TennisScorer.new(@player1Name, @player2Name, @p1points, @p2points).score
  end
end

