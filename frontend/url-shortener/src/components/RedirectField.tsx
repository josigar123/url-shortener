import Redirect from "../api/redirect";

const RedirectField: React.FC = () => {
  const handleSubmit = () => {
    console.log("Do work");
  };

  return (
    <>
      <form onSubmit={handleSubmit}>
        <input type="text" placeholder="Enter shortlink here..."></input>
      </form>
    </>
  );
};
