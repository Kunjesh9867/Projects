/*
  Created by Kunjesh Ramani
  Date: 26 April 2023
*/ 

'use strict';

// Selecting elements
const player0Element = document.querySelector('.player--0');
const player1Element = document.querySelector('.player--1');
const score0Element = document.querySelector('#score--0');
const score1Element = document.querySelector('#score--1'); // const score1Element = document.getElementById('#score--1');
const currentElement0 = document.querySelector('#current--0');
const currentElement1 = document.querySelector('#current--1');

const diceElement = document.querySelector('.dice'); // To select dice
const btnNew = document.querySelector('.btn--new');
const btnRoll = document.querySelector('.btn--roll');
const btnHold = document.querySelector('.btn--hold');
let scores, currentScore, activePlayer, playing;

// Starting conditions
const init = function () {
  scores = [0, 0];
  currentScore = 0;
  activePlayer = 0;
  playing = true;

  score0Element.textContent = 0;
  score1Element.textContent = 0;
  currentElement0.textContent = 0;
  currentElement1.textContent = 0;

  diceElement.classList.add('hidden');
  player0Element.classList.remove('player--winner');
  player1Element.classList.remove('player--winner');
  player0Element.classList.add('player--active');
  player1Element.classList.remove('player--active');
};

init(); // Calling the function so that the values can be initialised

// Switch player
function switchPlayer() {
  document.getElementById(`current--${activePlayer}`).textContent = 0;
  currentScore = 0;
  // Switch to next player
  activePlayer = activePlayer === 0 ? 1 : 0;
  player0Element.classList.toggle('player--active');
  player1Element.classList.toggle('player--active');
}

// When 'ROLL DICE' button is pressed
btnRoll.addEventListener('click', function () {
  if (playing) {
    // 1. Generating a random dice roll
    const dice = Math.trunc(Math.random() * 6) + 1;  // console.log(dice); // To check randomNumber

    // 2. Display dice
    diceElement.classList.remove('hidden'); // No '.hidden'
    diceElement.src = `./images/dice-${dice}.png`; // Literal template

    // 3. Check for rolled 1: if true, switch to next player
    if (dice !== 1) {
      // Add dice to current score
      currentScore += dice;
      document.getElementById(`current--${activePlayer}`).textContent = currentScore;
      // currentElement0.textContent = currentScore;  // It is only for player0, not for player1
    } else {
      switchPlayer();
    }
  }
});

// When 'ROLL DICE' button is pressed
btnHold.addEventListener('click', function () {
  if (playing) {
    // 1. Add current score to active player's score
    scores[activePlayer] += currentScore; // score[0] = score[0] + currentScore
    document.getElementById(`score--${activePlayer}`).textContent =
      scores[activePlayer];

    // 2. Check if player's score >=100 [Finish the game]
    if (scores[activePlayer] >= 100) {
      playing = false; // To make button unresponsive
      diceElement.classList.add('hidden'); // No '.hidden'
      document.querySelector(`.player--${activePlayer}`).classList.add('player--winner');
      document.querySelector(`.player--${activePlayer}`).classList.remove('player--active');
    } else {
      // Switch to the next player
      switchPlayer();
    }
  }
});

// When 'NEW GAME' button is pressed
btnNew.addEventListener('click', init);
