let todosContainer = document.getElementById("todos");

const todoInput = document.createElement("input");
todoInput.setAttribute("type", "text");
todoInput.setAttribute("placeholder", "Add a new todo");
todosContainer.appendChild(todoInput);
const todoButton = document.createElement("button");
todoButton.setAttribute("type", "button");
todoButton.textContent = "Add";
todosContainer.appendChild(todoButton);

function addTodo() {
  if (todoInput.value === "") {
    return;
  }
  const todoText = todoInput.value;
  const todoItem = document.createElement("li");
  todoItem.textContent = todoText;
  todosContainer.appendChild(todoItem);
  todoInput.value = "";
  const deleteButton = document.createElement("button");
  deleteButton.setAttribute("type", "button");
  deleteButton.textContent = "Delete";
  todoItem.appendChild(deleteButton);
  deleteButton.addEventListener("click", removeTodo);
}

function removeTodo() {
  todosContainer.removeChild(this.parentNode);
}

todoButton.addEventListener("click", addTodo);
