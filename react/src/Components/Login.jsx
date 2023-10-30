import { useRef, useEffect, useState } from "react";
import axios from "../API/axios";
import { Link, useNavigate, useLocation } from "react-router-dom";
import useAuth from "../Hooks/useAuth"

const Login = () => {

    const { setAuth } = useAuth();

    const navigate = useNavigate();
    const location = useLocation();
    const from = location.state?.from?.pathname || "/";


    const userNameRef = useRef();
    const errorRef = useRef();

    const [userName, setUserName] = useState("");
    const [password, setPassword] = useState("");
    const [errorMsg, setErrorMsg] = useState("");
    //const [success, setSuccess] = useState(false);

    useEffect(() => {
        userNameRef.current.focus();
    }, []);

    useEffect(() => {
        setErrorMsg("");
    }, [userName, password]);

    const handleSubmit = async (e) => {
        e.preventDefault();

        try {
            const response = await axios.post("Users/Login",
                JSON.stringify({ UserName: userName, Password: password }),
                {
                    headers: { "Content-Type": "application/json" },
                    withCredentials: true
                }
            );

            const accessToken = response?.data?.accessToken;
            const refreshToken = response?.data?.refreshToken;

            const roles = response?.data?.roles;

            console.log(response?.data);

            setAuth({ userName, accessToken, roles, refreshToken })
            //setSuccess(true);
            setUserName('');
            setPassword('');
            navigate(from, { replace: true });
        } catch (err) {
            if (!err?.response) {
                setErrorMsg('No Server Response');
            } else if (err.response?.status === 400) {
                setErrorMsg('Missing user name and/or password');
            } else if (err.response?.status === 401) {
                setErrorMsg('Unauthorized');
            } else {
                setErrorMsg('Login Failed')
            }

            errorRef.current.focus();
        }
    };

    return (
        <section>
            <p ref={errorRef} className={errorMsg ? "errmsg" : "offscreen"} aria-live="assertive">{errorMsg}</p>
            <h1>Sign in</h1>
            <form onSubmit={handleSubmit}>
                <label htmlFor="username">Username:</label>
                <input
                    type="text"
                    id="username"
                    ref={userNameRef}
                    autoComplete="off"
                    onChange={(e) => setUserName(e.target.value)}
                    value={userName}
                    required
                />
                <label htmlFor="password">Password:</label>
                <input
                    type="password"
                    id="password"
                    onChange={(e) => setPassword(e.target.value)}
                    value={password}
                    required
                />
                <button>Sign in</button>

            </form>

            <div className="flexGrow">
                <Link to="/">Home</Link>
            </div>
        </section>
    )
};

export default Login;
