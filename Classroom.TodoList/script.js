let todosContainer = document.getElementById("todos");
let todoInput;
let checkBox;
createElements();

function addTodo() {
  if (todoInput.value === "") {
    return;
  }
  const todoText = todoInput.value;
  const todoContainer = document.createElement("div");
  todoContainer.classList.add("todo-container");
  todosContainer.appendChild(todoContainer);
  const checkBoxContainer = document.createElement("div");
  checkBoxContainer.classList.add("check-box-container");
  todoContainer.appendChild(checkBoxContainer);
  checkBox = document.createElement("input");
  checkBox.setAttribute("type", "checkbox");
  checkBox.classList.add("check-box");
  checkBoxContainer.appendChild(checkBox);
  const todoItem = document.createElement("li");
  todoItem.textContent = todoText;
  todoItem.classList.add("todo-item");
  checkBoxContainer.appendChild(todoItem);
  todoInput.value = "";

  const inputContainer = document.createElement("div");
  inputContainer.classList.add("input-container");
  todoContainer.appendChild(inputContainer);
  const deleteButton = document.createElement("button");
  deleteButton.setAttribute("type", "button");
  deleteButton.textContent = "Delete";
  deleteButton.classList.add("delete-btn");
  inputContainer.appendChild(deleteButton);

  const editButton = document.createElement("button");
  editButton.setAttribute("type", "button");
  editButton.textContent = "Edit";
  editButton.classList.add("edit-btn");
  inputContainer.appendChild(editButton);
  editButton.addEventListener("click", editTodo);

  deleteButton.addEventListener("click", removeTodo);

  checkBox.addEventListener("click", completeTodo);
}

function createElements() {
  const inputContainer = document.createElement("div");
  inputContainer.classList.add("input-container");
  todosContainer.appendChild(inputContainer);
  todoInput = document.createElement("input");
  todoInput.setAttribute("type", "text");
  todoInput.setAttribute("maxlength", "20");
  todoInput.setAttribute("placeholder", "Add a new todo");
  todoInput.classList.add("todo-input");
  inputContainer.appendChild(todoInput);
  const todoButton = document.createElement("button");
  todoButton.setAttribute("type", "button");
  todoButton.textContent = "Add";
  todoButton.classList.add("add-btn");
  inputContainer.appendChild(todoButton);
  todoButton.addEventListener("click", addTodo);
}

function removeTodo() {
  todosContainer.removeChild(this.parentNode);
}

function saveTodo() {
  const todoItem = this.parentNode;
  const todoText = todoItem.firstChild.value;

  const newTodoText = document.createElement("span");
  newTodoText.textContent = todoText;
  newTodoText.classList.add("todo-item");
  todoItem.replaceChild(newTodoText, todoItem.firstChild);
  todoItem.removeChild(this);
}

function editTodo() {
  const todoItem = this.parentNode.parentNode;

  // Check if the first child is an input element
  const isInput = todoItem.firstChild instanceof HTMLInputElement;

  // Get the current todoText based on whether it's an input or text node
  const todoText = isInput
    ? todoItem.firstChild.value
    : todoItem.firstChild.textContent;

  const editInput = document.createElement("input");
  editInput.setAttribute("type", "text");
  editInput.setAttribute("value", todoText);
  editInput.classList.add("todo-input");
  todoItem.replaceChild(editInput, todoItem.firstChild);

  // If it's an input element, set the value to todoText
  if (isInput) {
    editInput.value = todoText;
  }

  if (todoItem.lastChild.textContent === "Save") {
    return;
  }

  const saveButton = document.createElement("button");
  saveButton.setAttribute("type", "button");
  saveButton.textContent = "Save";
  saveButton.classList.add("edit-btn");
  todoItem.appendChild(saveButton);

  saveButton.addEventListener("click", saveTodo);
}

function completeTodo() {
  const todoItem = this.parentNode;
  todoItem.classList.toggle("completed");
  console.log("completed");
}
