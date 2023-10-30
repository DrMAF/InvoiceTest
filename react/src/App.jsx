import Register from './Components/Register';
import Login from "./Components/Login";
import Home from "./Components/Home";
import Layout from "./Components/Layout";
import Editor from "./Components/Editor";
import Admin from "./Components/Admin";
import Missing from "./Components/Missing";
import Unauthorized from "./Components/Unauthorized";
import Lounge from "./Components/Lounge";
import LinkPage from "./Components/LinkPage";
import RequireAuth from "./Components/RequireAuth";
import { Routes, Route } from "react-router-dom";

function App() {
    return (
        <Routes>
            <Route path="/" element={<Layout />}>
                <Route path="login" element={<Login />} />
                <Route path="register" element={<Register />} />
                <Route path="linkpage" element={<LinkPage />} />
                <Route path="unauthorized" element={<Unauthorized />} />

                <Route element={<RequireAuth allowedRoles={["admin", "editor"]} />}>
                    <Route path="/" element={<Home />} />
                </Route>
                <Route element={<RequireAuth allowedRoles={["editor"]} />}>
                    <Route path="editor" element={<Editor />} />
                </Route>
                <Route element={<RequireAuth allowedRoles={["admin"]} />}>
                    <Route path="admin" element={<Admin />} />
                </Route>
                <Route element={<RequireAuth allowedRoles={["admin", "editor"]} />}>
                    <Route path="lounge" element={<Lounge />} />
                </Route>

                <Route path="*" element={<Missing />} />
            </Route>
        </Routes>
    );
}

export default App;