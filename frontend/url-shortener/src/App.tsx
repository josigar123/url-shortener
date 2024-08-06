import { useEffect, useState } from "react";
import "./App.css";
import axios from "axios";

function App() {
	const [hit, setHit] = useState(0);

	const postData = {
		url: "mymagicurl.net",
	};

	const test = () => {
		axios
			.post("http://localhost:5249/api/ShortLink", null, { params: postData })
			.then((response) => {
				console.log(response.data);
			});
	};

	return (
		<>
			<button
				onClick={() => {
					setHit(1);
				}}
			>
				POST ME
			</button>
			{hit == 1 ? test() : console.log("No post yet")}
		</>
	);
}

export default App;
