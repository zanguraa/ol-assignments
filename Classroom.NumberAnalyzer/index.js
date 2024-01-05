let arrayofNumbers = [1, 2, 3, 4, 5, 6, 7, 8, 9];

function calculateSum(arrayofNumbers) {
  let sum = 0;

  for (let i = 0; i < arrayofNumbers.length; i++) {
    sum += arrayofNumbers[i];
  }

  return sum;
}

function calculateMin(arrayofNumbers) {
  let min = arrayofNumbers[0];

  for (let i = 0; i < arrayofNumbers.length; i++) {
    if (arrayofNumbers[i] < min) {
      min = arrayofNumbers[i];
    }
  }

  return min;
}

function calculateMax(arrayofNumbers) {
  let max = arrayofNumbers[0];

  for (let i = 0; i < arrayofNumbers.length; i++) {
    if (arrayofNumbers[i] > max) {
      max = arrayofNumbers[i];
    }
  }

  return max;
}

function findEvenNumbers(arrayofNumbers) {
  let evenNumbers = [];

  for (let i = 0; i < arrayofNumbers.length; i++) {
    if (arrayofNumbers[i] % 2 === 0) {
      evenNumbers.push(arrayofNumbers[i]);
    }
  }

  return evenNumbers;
}


console.log(`sum numbers:  ${calculateSum(arrayofNumbers)} `);
console.log(`calculate min: ${calculateMin(arrayofNumbers)}`);
console.log(`calculate max: ${calculateMax(arrayofNumbers)}`);
console.log(`even numbers: ${findEvenNumbers(arrayofNumbers)}`);