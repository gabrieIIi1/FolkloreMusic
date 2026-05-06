import { useEffect, useState } from "react";
import {
    listarMusicas,
    cadastrarMusica,
    deletarMusica,
} from "../services/musicaService";

import "../styles/home.css";

function Home() {
    const [musicas, setMusicas] = useState([]);
    const [titulo, setTitulo] = useState("");
    const [artista, setArtista] = useState("");
    const [genero, setGenero] = useState("");
    const [capaUrl, setCapaUrl] = useState("");
    const [linkUrl, setLinkUrl] = useState("");

    async function carregarMusicas() {
        const dados = await listarMusicas();
        setMusicas(dados);
    }

    async function adicionarMusica(e) {
        e.preventDefault();

        await cadastrarMusica({ titulo, artista, genero, capaUrl, linkUrl });

        setTitulo("");
        setArtista("");
        setGenero("");
        setCapaUrl("");
        setLinkUrl("");

        carregarMusicas();
    }

    async function removerMusica(id) {
        await deletarMusica(id);
        carregarMusicas();
    }

    useEffect(() => {
        carregarMusicas();
    }, []);

    return (
        <main>
            <nav className="navbar">
                <div className="menu">
                    <a>Explore</a>
                    <a>Collections</a>
                    <a>About</a>
                    <a>Reviews</a>
                </div>

                <h2 className="logo">FOLKLORE</h2>

                <span className="search">⌕</span>
            </nav>

            <section className="hero">
                <h1>your voice</h1>

                <div className="hero-card">
                    <img
                        src="https://i.scdn.co/image/ab67616d0000b27395f754318336a07e85ec59bc"
                        alt="album"
                    />
                </div>

                <div className="hero-bottom">
                    <div>
                        <p className="small">About us</p>
                        <h3>What we hear</h3>
                    </div>

                    <p className="description">
                        A creative music library made to save your favorite sounds,
                        artists and albums in one aesthetic collection.
                    </p>
                </div>
            </section>

            <section className="form-section">
                <h2>ADD NEW TRACK</h2>

                <form onSubmit={adicionarMusica} className="formulario">
                    <input
                        type="text"
                        placeholder="Título"
                        value={titulo}
                        onChange={(e) => setTitulo(e.target.value)}
                    />

                    <input
                        type="text"
                        placeholder="Artista"
                        value={artista}
                        onChange={(e) => setArtista(e.target.value)}
                    />

                    <input
                        type="text"
                        placeholder="Gênero"
                        value={genero}
                        onChange={(e) => setGenero(e.target.value)}
                    />

                    <input
                        type="text"
                        placeholder="URL da capa"
                        value={capaUrl}
                        onChange={(e) => setCapaUrl(e.target.value)}
                    />
                    <input
                        type="text"
                        placeholder="URL do Spotify ou YouTube"
                        value={linkUrl}
                        onChange={(e) => setLinkUrl(e.target.value)}
                    />

                    <button type="submit">Adicionar →</button>
                </form>
            </section>

            <section className="collection">
                <div className="section-title">
                    <span>Bloggers' Choice</span>
                    <h2>NEW ARRIVALS</h2>
                    <span>Bestsellers</span>
                </div>

                <div className="grid">
                    {musicas.map((musica) => (
                        <div className="card" key={musica.id}>
                            <div className="image-box">
                                <span className="eco">♪ ECO</span>
                                <img src={musica.capaUrl} alt={musica.titulo} />
                            </div>

                            <h3>{musica.titulo}</h3>

                            <p>{musica.artista}</p>

                            <span className="genero">
                                {musica.genero}
                            </span>

                            <div className="card-actions">
                                <a
                                    href={musica.linkUrl}
                                    target="_blank"
                                    rel="noreferrer"
                                    className="listen-button"
                                >
                                    ouvir álbum →
                                </a>

                                <button
                                    onClick={() => removerMusica(musica.id)}
                                >
                                    remover
                                </button>
                            </div>
                        </div>
                    ))}
                </div>
            </section>

            <section className="about">
                <div>
                    <p>
                        This project was built with React and .NET Web API, using a layered
                        architecture, services, controllers and Entity Framework.
                    </p>

                    <button>More about us →</button>
                </div>

                <h2>FOLKLORE</h2>
            </section>
        </main>
    );
}

export default Home;