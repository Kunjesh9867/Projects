/*
  Created by Kunjesh Ramani
  Date: 24 April 2023
*/

'use strict';
// console.log(document.querySelector('.message').textContent); // To get the textcontent & it is also used to SET the textcontent
// document.querySelector('.message').textContent = 'Correct Number🥳';

// document.querySelector('.number').textContent = 13;
// document.querySelector('.score').textContent = 10 ;

// document.querySelector('.guess').value = 23; // To set the value
// console.log(document.querySelector('.guess').value);

// Handling Click Events

let secretNumber = Math.trunc(Math.random() * 20) + 1; // 1-20 (without +1 = 0-19)
let score = Number(document.querySelector('.score').textContent);
let highscore = 0;

function displayMesage(message) {
  document.querySelector('.message').textContent = message;
}

document.querySelector('.check').addEventListener(
  'click', // click is event = concrete
  function () {
    const guess = Number(document.querySelector('.guess').value);
    if (!guess) { // When there is no input
      displayMesage('🛑 No number'); // document.querySelector('.message').textContent = '🛑 No number';
    }

    // When Player wins
    else if (guess === secretNumber) { // Strict check (no coercion)
      displayMesage('🥳 Correct Number '); // document.querySelector('.message').textContent = '🥳 Correct Number ';
      // adding CSS using JS
      document.querySelector('body').style.backgroundColor = '#60b347';
      document.querySelector('.number').style.width = '30rem';
      document.querySelector('.number').textContent = secretNumber;
      if (score > highscore) {
        highscore = score;
      }
      document.querySelector('.highscore').textContent = highscore;
    }

    // Refactoring Code
    else if (guess !== secretNumber) {
      if (score > 1) {
        displayMesage(guess > secretNumber ? '📈 Too High!' : '📉 Too Low!'); // document.querySelector('.message').textContent =   guess>secretNumber ? '📈 Too High!' : '📉 Too Low!';
        score--;
        document.querySelector('.score').textContent = score;
      } else {
        displayMesage('💥 You lost the game!'); // document.querySelector('.message').textContent ='💥 You lost the game!';
        document.querySelector('.score').textContent = 0;
      }
    }

    // // When guess is too high
    // We have applied DRY principle

    // else if (guess > secretNumber) {
    //   if (score > 1) {
    //     document.querySelector('.message').textContent = '📈 Too High!';
    //     score--;
    //     document.querySelector('.score').textContent = score;
    //   } else {
    //     document.querySelector('.message').textContent =
    //       '💥 You lost the game!';
    //     document.querySelector('.score').textContent = 0;
    //   }
    // }

    // // When guess is too low
    // else if (guess < secretNumber) {
    //   if (score > 1) {
    //     document.querySelector('.message').textContent = '📉 Too Low!';
    //     score--;
    //     document.querySelector('.score').textContent = score;
    //   } else {
    //     document.querySelector('.message').textContent =
    //       '💥 You lost the game!';
    //     document.querySelector('.score').textContent = 0;
    //   }
    // }
  }
);

// Concept
// The function in the Event = Will not execute during the script
// It will execute as soon as the function is called!

document.querySelector('.again').addEventListener('click', function () {
  document.querySelector('.number').textContent = '?';
  document.querySelector('body').style.backgroundColor = '#222';
  document.querySelector('.number').style.width = '15rem';
  document.querySelector('.score').textContent = '20';
  secretNumber = Math.trunc(Math.random() * 20) + 1;
  score = 20;
  displayMesage('Start guessing...'); // document.querySelector('.message').textContent = 'Start guessing...';
  document.querySelector('.guess').value = '';
});
