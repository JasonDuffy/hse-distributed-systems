# HSE Distributed Systems ToDo-List

[![GPLv3 License](https://img.shields.io/badge/License-GPL%20v3-yellow.svg)](https://www.gnu.org/licenses/gpl-3.0.html)

A simple backend implementation of a ToDo list created as part of the laboratory of the sixth-semester course "Parallel and Distributed Systems".




## Features

Simple managing of a ToDo list:
- Adding and removing ToDos in database
- Getting all ToDos in database


## Tech Stack

**Server:** ASP.NET 8.0, PostgreSQL, Docker


## API Reference

#### Get all todos

```http
  GET /todos
```

#### Add todo

```http
  POST /todos/${todo}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `todo`      | `string` | **Required**. Text of ToDo to add. |

#### Delete todo

```http
  DELETE /todos/${todo}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `todo`      | `string` | **Required**. Text of ToDo to remove. |


## Run Locally

Clone the project

```bash
  git clone https://github.com/JasonDuffy/hse-distributed-systems.git
```

Go to the project directory

```bash
  cd TodoList-Backend
```

Start Docker

```bash
  docker compose up
```

Access any of the frontends

```bash
  http://localhost:8090
```
```bash
  http://localhost:5001
```

## Authors

- [Jason Patrick Duffy](https://github.com/JasonDuffy)
- [Tom Nguyen Dinh](https://github.com/tomhuy-w)
## License

[GNU GPLv3](./COPYING)


## Acknowledgements

Our lecturers and creators of the frontends:
 - [Matthias Haeussler](https://github.com/maeddes)
 - [Cagri Tasci](https://github.com/StraysWonderland)

This README was created using:
 - [README Editor](https://readme.so/)

