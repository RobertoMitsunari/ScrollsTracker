import { useEffect, useState } from "react";
import MangaShelf from "../components/MangaShelf";
import { Link } from "react-router-dom";

function Biblioteca() {
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
      <div className="flex justify-between items-center pl-2 pr-2 mb-1">
        <h1 className="text-white">Biblioteca</h1>
        <Link to="/cadastrar-obra" className="text-white lg:block bg-transparent text-primary border hover:bg-primary border-primary hover:text-darkmode px-4 py-2 rounded-lg cursor-pointer">Nova Obra</Link>
      </div>
      <div className="border-b-2 border-white pl-2 pr-2">
        <h1 className="text-white">Obras:</h1>
      </div>
      <MangaShelf obras={obras} />
    </div>
  );
}

export default Biblioteca;
