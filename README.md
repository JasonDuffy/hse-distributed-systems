# HSE Distributed Systems ToDo-List

[![GPLv3 License](https://img.shields.io/badge/License-GPL%20v3-yellow.svg)](https://www.gnu.org/licenses/gpl-3.0.html)

A simple backend implementation of a ToDo list created as part of the laboratory of the sixth-semester course "Parallel and Distributed Systems".




## Features

Simple managing of a ToDo list:
- Adding and removing ToDos in database
- Getting all ToDos in database


## Tech Stack

**Server:** ASP.NET 8.0, PostgreSQL, Docker


## Requirements

To run this project, an installation of [Docker](https://www.docker.com/) is required.


## API Reference

#### Get all todos

```http
  GET /todos
```

| Return | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `todo`      | `string array` | All saved ToDos as array. |

Status codes:
| Code | Description |
| :-------- | :-------  |
| 200      | Successfully returned ToDos |

#### Add todo

```http
  POST /todos/${todo}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `todo`      | `string` | **Required**. Text of ToDo to add. |

Status codes:
| Code | Description |
| :-------- | :-------  |
| 200      | Server tried adding a ToDo and did not run into any server errors. (Does not mean the Todo was added, duplicates are ignored!) |

#### Delete todo

```http
  DELETE /todos/${todo}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `todo`      | `string` | **Required**. Text of ToDo to remove. |

Status codes:
| Code | Description |
| :-------- | :-------  |
| 200      | Server tried removing a ToDo and did not run into any server errors. (Does not mean a Todo was removed!) |

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

