let questionEl = document.querySelector(".question");
let choices = document.getElementById("quiz").querySelector(".answers");
let currentQuestion = 0;
let score = 0;

let questions = [
  {
    question: "Which country is the last world cup champion in football?",
    choices: ["France", "Brazil", "Germany", "Argentina"],
    correctAnswer: "Argentina",
  },
  {
    question: "Deepest lake in the world?",
    choices: [
      "Lake Baikal",
      "Lake Superior",
      "Lake Victoria",
      "Lake Tanganyika",
    ],
    correctAnswer: "Lake Baikal",
  },
  {
    question: "What is the capital of Australia?",
    choices: ["Sydney", "Melbourne", "Canberra", "Perth"],
    correctAnswer: "Canberra",
  },
  {
    question: "What is the capital of Canada?",
    choices: ["Toronto", "Vancouver", "Ottawa", "Montreal"],
    correctAnswer: "Ottawa",
  },
  {
    question: "Which country is 1st in the world in population?",
    choices: ["China", "India", "USA", "Indonesia"],
    correctAnswer: "China",
  },
];

// Function to update the question and choices in the HTML
function updateQuestion() {
  questionEl.textContent = questions[currentQuestion].question;
  choices.innerHTML = "";
  for (let i = 0; i < questions[currentQuestion].choices.length; i++) {
    currentQuestion++;
  }
}

updateQuestion();

function answerChoices() {
  for (let i = 0; i < questions[currentQuestion].choices.length; i++) {
    let choice = document.createElement("button");
    choice.textContent = questions[currentQuestion].choices[i];
    choices.appendChild(choice);
  }
}

answerChoices();

// Function to check if the answer is correct
function checkAnswer(event) {
  if (event.target.textContent === questions[currentQuestion].correctAnswer) {
    score++;
  }
  currentQuestion++;
  if (currentQuestion < questions.length) {
    updateQuestion();
  } else {
    choices.innerHTML = "";
    questionEl.textContent = `Your score is ${score}`;
  }
}

choices.addEventListener("click", checkAnswer);



