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
  const checkBoxContainer = document.createElement("div");
  const todoItem = document.createElement("li");
  const inputContainer = document.createElement("div");
  const deleteButton = document.createElement("button");
  const editButton = document.createElement("button");

  todoContainer.classList.add("todo-container");
  todosContainer.appendChild(todoContainer);
  checkBoxContainer.classList.add("check-box-container");
  todoContainer.appendChild(checkBoxContainer);
  checkBox = document.createElement("input");
  checkBox.setAttribute("type", "checkbox");
  checkBox.classList.add("check-box");
  checkBoxContainer.appendChild(checkBox);
  todoItem.textContent = todoText;
  todoItem.classList.add("todo-item");
  checkBoxContainer.appendChild(todoItem);
  todoInput.value = "";
  inputContainer.classList.add("input-container");
  todoContainer.appendChild(inputContainer);
  deleteButton.setAttribute("type", "button");
  deleteButton.textContent = "Delete";
  deleteButton.classList.add("delete-btn");
  inputContainer.appendChild(deleteButton);

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
  const todoButton = document.createElement("button");
  todoInput = document.createElement("input");

  inputContainer.classList.add("input-container");
  todosContainer.appendChild(inputContainer);
  todoInput.setAttribute("type", "text");
  todoInput.setAttribute("maxlength", "20");
  todoInput.setAttribute("placeholder", "Add a new todo");
  todoInput.classList.add("todo-input");
  inputContainer.appendChild(todoInput);
  todoButton.setAttribute("type", "button");
  todoButton.textContent = "Add";
  todoButton.classList.add("add-btn");
  inputContainer.appendChild(todoButton);
  todoButton.addEventListener("click", addTodo);
}

function removeTodo() {
  todosContainer.removeChild(this.parentNode.parentNode);
}

function saveTodo() {
  const todoItem = this.parentNode;
  const todoText = todoItem.querySelector(".todo-input").value;

  if (!todoText.trim()) {
    alert("Please enter a valid todo text.");
    return;
  }

  const checkBoxContainer = document.createElement("div");
  checkBoxContainer.classList.add("check-box-container");
  const checkBox = document.createElement("input");
  checkBox.setAttribute("type", "checkbox");
  checkBox.classList.add("check-box");
  checkBoxContainer.appendChild(checkBox);

  const newTodoText = document.createElement("li");
  newTodoText.textContent = todoText;
  newTodoText.classList.add("todo-item");
  checkBoxContainer.appendChild(newTodoText);

  const inputContainer = document.createElement("div");
  inputContainer.classList.add("input-container");
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

  todoItem.replaceChildren(checkBoxContainer, inputContainer);
}

function editTodo() {
  const todoItem = this.parentNode.parentNode;
  const isInput = todoItem.firstChild instanceof HTMLInputElement;
  const inputContainer = document.createElement("div");
  inputContainer.classList.add("input-container");

  const todoText = isInput
    ? todoItem.firstChild.value
    : todoItem.querySelector(".todo-item").textContent;

  const checkBoxContainer = document.createElement("div");
  checkBoxContainer.classList.add("check-box-container");
  const checkBox = document.createElement("input");
  checkBox.setAttribute("type", "checkbox");
  checkBox.classList.add("check-box");
  checkBoxContainer.appendChild(checkBox);
  inputContainer.appendChild(checkBoxContainer);
  checkBox.checked = false;

  const editInput = document.createElement("input");
  editInput.setAttribute("type", "text");
  editInput.setAttribute("value", todoText);
  editInput.classList.add("todo-input");
  inputContainer.appendChild(editInput);

  todoItem.replaceChildren(inputContainer);

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
