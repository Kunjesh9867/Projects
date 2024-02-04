//Assignment-1
//Group-2: Aarsh Parimal Patel - 200520260,
//Daxil Ashishkumar Patel - 200520270,
//Kunjesh Kantilal Ramani - 200515106

// Variables to store the generated sentence and expected button
let sentence = "";
let expectedButtonId = "first";

// Arrays for sentence generation
const first = [
  "The turkey",
  "Mom",
  "Dad",
  "The dog",
  "My teacher",
  "The elephant",
  "The cat",
];
const second = [
  "sat on",
  "ate",
  "danced with",
  "saw",
  "doesn't like",
  "kissed",
];
const third = [
  "a funny",
  "a scary",
  "a goofy",
  "a slimy",
  "a barking",
  "a fat",
];
const fourth = ["goat", "monkey", "fish", "cow", "frog", "bug", "worm"];
const fifth = [
  "on the moon",
  "on the chair",
  "in my spaghetti",
  "in my soup",
  "on the grass",
  "in my shoes",
];

// Button elements
const firstBtn = document.querySelector("#first");
const secondBtn = document.querySelector("#second");
const thirdBtn = document.querySelector("#third");
const fourthBtn = document.querySelector("#fourth");
const fifthBtn = document.querySelector("#fifth");
const resetStory = document.querySelector("#reset");
const createStory = document.querySelector("#create");
const para = document.querySelector("#para");
const paraError = document.querySelector("#paraError");
const randomStoryBtn = document.querySelector("#randomStory");

// Function to generate a random story
function makeRandomStory() {
  let result = "";
  result +=
    first[Math.floor(Math.random() * first.length)] +
    " " +
    second[Math.floor(Math.random() * second.length)] +
    " " +
    third[Math.floor(Math.random() * third.length)] +
    " " +
    fourth[Math.floor(Math.random() * fourth.length)] +
    " " +
    fifth[Math.floor(Math.random() * fifth.length)];

  return result;
}

// Function to speak the given text
function speak(text) {
  const utterance = new SpeechSynthesisUtterance(text);
  speechSynthesis.speak(utterance);
}

// Function to reset the story and expected button
function reset() {
  sentence = "";
  para.textContent = "";
  paraError.textContent = "";
  expectedButtonId = "first";
}

// Button click for event listeners
firstBtn.addEventListener("click", function () {
  const word = first[Math.floor(Math.random() * first.length)];
  speak(word);
  if (expectedButtonId === "first") {
    sentence += word + " ";
    expectedButtonId = "second";
  }
});

secondBtn.addEventListener("click", function () {
  const word = second[Math.floor(Math.random() * second.length)];
  speak(word);
  if (expectedButtonId === "second") {
    sentence += word + " ";
    expectedButtonId = "third";
  }
});

thirdBtn.addEventListener("click", function () {
  const word = third[Math.floor(Math.random() * third.length)];
  speak(word);
  if (expectedButtonId === "third") {
    sentence += word + " ";
    expectedButtonId = "fourth";
  }
});

fourthBtn.addEventListener("click", function () {
  const word = fourth[Math.floor(Math.random() * fourth.length)];
  speak(word);
  if (expectedButtonId === "fourth") {
    sentence += word + " ";
    expectedButtonId = "fifth";
  }
});

fifthBtn.addEventListener("click", function () {
  const word = fifth[Math.floor(Math.random() * fifth.length)];
  speak(word);
  if (expectedButtonId === "fifth") {
    sentence += word + " ";
    expectedButtonId = null;
  }
});

//resets the story
resetStory.addEventListener("click", function () {
  reset();
});

//creates the story
createStory.addEventListener("click", function () {
  if (expectedButtonId === null) {
    if (sentence.trim() !== "") {
      para.textContent = sentence;
      speak(sentence);
    }
  } 
  //for error while generating a sentence incorrectly
  else {
    paraError.textContent =
      "Please click all the buttons below sequentially and then click create to form a sentence or click random story to create a random sentence!!!";
  }
});

randomStoryBtn.addEventListener("click", function () {
  reset();
  const randomSentence = makeRandomStory();
  speak(randomSentence);
  para.textContent = randomSentence;
});
//end of js code