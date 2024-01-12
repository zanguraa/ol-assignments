function guessTheNumber() {
  let number = Math.floor(Math.random(1) * 100);
  let guess = prompt("Guess a number between 1 and 100");

  
  while (guess != number) {
    if (guess > number) {
      guess = prompt("Too high, guess again");
    } else {
      guess = prompt("Too low, guess again");
    }
  }
  alert("You got it! The number was " + number);

  console.log(number);
}
guessTheNumber();
