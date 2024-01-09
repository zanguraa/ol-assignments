let numbers = document.querySelectorAll(".numbers");
let operators = document.querySelectorAll(".operators");
let display = document.querySelector(".display-input");
let reset = document.querySelector("#clear");
let result = document.querySelector("#equal");

numbers.forEach((number) => {
  number.addEventListener("click", () => {
    display.value += number.innerHTML;
  });
});

const addition = (a, b, op) => {
  return `${a} ${op} ${b}`;
};

operators.forEach((operator) => {
  operator.addEventListener("click", () => {
    display.value += operator.innerHTML;
  });
});

reset.addEventListener("click", () => {
  display.value = "";
});

result.addEventListener("click", () => {
 
    let input = display.value;
    let regex = /(\d+)(\+|-|\*|\/)(\d+)/;
    let match = input.match(regex);
    let a = parseInt(match[1]);
    let b = parseInt(match[3]);
    let op = match[2];
    let result = 0;
    switch (op) {
        case "+":
        result = a + b;
        break;
        case "-":
        result = a - b;
        break;
        case "*":
        result = a * b;
        break;
        case "/":
        if (b == 0) {
            result = "Error";
        } else {
            result = a / b;
        }
        break;
    }
    display.value = result;
});
