// fetch("https://reqres.in/api/users?page=2", {
//   method: "GET",
//   headers: {
//     "Content-Type": "application/json",
//   },
// })
//   .then((response) => response.json())
//   .then((data) => console.log(data))
//   .catch((error) => console.log("Error: ", error));

async function getData() {
  const response = await fetch("https://reqres.in/api/users?page=2");
  const data = await response.json();
  console.log(data);
}
getData();

async function postData() {
  const response = await fetch("https://reqres.in/api/users", {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({
      name: "morpheus",
      job: "leader",
    }),
  });

  const json = await response.json();
  console.log(json);
}

postData();

// fetch("https://reqres.in/api/users", {
//   method: "POST",
//   headers: {
//     "Content-Type": "application/json",
//   },
//   body: JSON.stringify({
//     name: "morpheus",
//     job: "leader",
//   }),
// })
//   .then((response) => response.json())
//   .then((data) => console.log(data))
//   .catch((error) => console.log("Error: ", error));
