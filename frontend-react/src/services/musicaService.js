import axios from "axios";

const API_URL = "http://localhost:5136/api/musicas";

export async function listarMusicas() {
  const response = await axios.get(API_URL);
  return response.data;
}

export async function cadastrarMusica(musica) {
  const response = await axios.post(API_URL, musica);
  return response.data;
}

export async function deletarMusica(id) {
  await axios.delete(`${API_URL}/${id}`);
}