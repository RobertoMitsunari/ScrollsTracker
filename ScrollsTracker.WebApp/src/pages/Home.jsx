import { useEffect, useState } from "react";
import MangaShelf from "../components/MangaShelf";

function Home() {
  const [obras, setObras] = useState([]);

  useEffect(() => {
    const controller = new AbortController();

    const fetchObras = async () => {
      try {
        const response = await fetch(
          "https://localhost:7071/api/ScrollsTracker/Obras",
          {
            method: "GET",
            signal: controller.signal,
          }
        );
        const data = await response.json();
        console.log("Dados recebidos:", data);
        setObras(data);
      } catch (error) {
        if (error.name === "AbortError") {
          console.log("Fetch abortado!");
        } else {
          console.error("Erro na requisição:", error);
        }
      }
    };

    fetchObras();

    return () => {
      console.log("Componente desmontado, abortando fetch...");
      controller.abort();
    };
  }, []);

  return (
    <div className="space-y-4">
      <div>
        <h1 className="text-white">Bem-vindo ao ScrollsMaster</h1>
      </div>
      <div className="border-b-2 border-white">
        <h1 className="text-white">Ultimos lançamentos</h1>
      </div>
      <MangaShelf obras={obras} />
    </div>
  );
}

export default Home;
