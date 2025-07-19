import MangaItem from "../components/MangaItem.jsx";

function MangaShelf(props) {
  const { obras } = props;
  return (
    <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6 p-4">
      {obras.map((obra) => (
        <MangaItem
          titulo={obra.titulo}
          descricao={obra.descricao}
          imagem={obra.imagem}
          ultimoCapitulo={obra.totalCapitulos}
          key={obra.id}
        />
      ))}
    </div>
  );
}

export default MangaShelf;
