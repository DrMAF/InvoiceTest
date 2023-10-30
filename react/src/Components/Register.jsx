import { useRef, useState, useEffect } from "react";
import { faCheck, faTimes, faInfoCircle } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import axios from '../API/axios';
import { Link } from "react-router-dom";


const USER_REGEX = /^[A-z][A-z0-9-_]{3,23}$/;
const PWD_REGEX = /^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#$%]).{8,24}$/;
const REGISTER_URL = 'user/register';

const Register = () => {

    const userNameRef = useRef();
    const errorRef = useRef();

    const [userName, setUserName] = useState("");
    const [validUserName, setValidUserName] = useState(false);
    const [userNameFocus, setUserNameFocus] = useState(false);

    const [password, setPassword] = useState("");
    const [validPassword, setValidPassword] = useState(false);
    const [passwordFocus, setPasswordFocus] = useState(false);

    const [matchPassword, setMatchPassword] = useState("");
    const [validMatchPassword, setValidMatchPassword] = useState(false);
    const [matchPasswordFocus, setMatchPasswordFocus] = useState(false);

    const [errorMsg, setErrorMsg] = useState("");
    const [success, setSuccess] = useState(false);

    useEffect(() => {
        userNameRef.current.focus();
    }, []);

    useEffect(() => {
        setValidUserName(USER_REGEX.test(userName));

    }, [userName]);

    useEffect(() => {
        setValidPassword(PWD_REGEX.test(password));
        setValidMatchPassword(matchPassword == password);
    }, [password, matchPassword]);

    useEffect(() => {
        setErrorMsg("");
    }, [userName, password, matchPassword]);

    const handleSubmit = async (e) => {
        e.preventDefault();
        // if button enabled with JS hack
        const v1 = USER_REGEX.test(userName);
        const v2 = PWD_REGEX.test(password);
        if (!v1 || !v2) {
            setErrorMsg("Invalid Entry");
            return;
        }
        try {
            const response = await axios.post(REGISTER_URL,
                JSON.stringify({ UserName: userName, Password: password, ConfirmPassword: matchPassword }),
                {
                    headers: { 'Content-Type': 'application/json' },
                    withCredentials: true
                }
            );
            console.log(response?.data);
            console.log(response?.accessToken);
            console.log(JSON.stringify(response))
            setSuccess(true);
            //clear state and controlled inputs
            //need value attrib on inputs for this
            setUserName('');
            setPassword('');
            setMatchPassword('');
        } catch (err) {
            if (!err?.response) {
                setErrorMsg('No Server Response');
            } else if (err.response?.status === 409) {
                setErrorMsg('Username Taken');
            } else {
                setErrorMsg('Registration Failed')
            }

            errorRef.current.focus();
        }
    };


    return (
        <>
            {success ? (
                <section>
                    <h1>Success!</h1>
                    <p>
                        <a href="#">Sign In</a>
                    </p>
                </section>
            ) : (
                <section>
                    <p ref={errorRef} className={errorMsg ? "errmsg" : "offscreen"} aria-live="assertive">{errorMsg}</p>
                    <h1>Register</h1>
                    <form onSubmit={handleSubmit}>
                        <label htmlFor="username">
                            Username:
                            <FontAwesomeIcon icon={faCheck} className={validUserName ? "valid" : "hide"} />
                            <FontAwesomeIcon icon={faTimes} className={validUserName || !userName ? "hide" : "invalid"} />
                        </label>
                        <input
                            type="text"
                            id="username"
                            ref={userNameRef}
                            autoComplete="off"
                            onChange={(e) => setUserName(e.target.value)}
                            value={userName}
                            required
                            aria-invalid={validUserName ? "false" : "true"}
                            aria-describedby="uidnote"
                            onFocus={() => setUserNameFocus(true)}
                            onBlur={() => setUserNameFocus(false)}
                        />
                        <p id="uidnote" className={userNameFocus && userName && !validUserName ? "instructions" : "offscreen"}>
                            <FontAwesomeIcon icon={faInfoCircle} />
                            4 to 24 characters.<br />
                            Must begin with a letter.<br />
                            Letters, numbers, underscores, hyphens allowed.
                        </p>


                        <label htmlFor="password">
                            Password:
                            <FontAwesomeIcon icon={faCheck} className={validPassword ? "valid" : "hide"} />
                            <FontAwesomeIcon icon={faTimes} className={validPassword || !password ? "hide" : "invalid"} />
                        </label>
                        <input
                            type="password"
                            id="password"
                            onChange={(e) => setPassword(e.target.value)}
                            value={password}
                            required
                            aria-invalid={validPassword ? "false" : "true"}
                            aria-describedby="pwdnote"
                            onFocus={() => setPasswordFocus(true)}
                            onBlur={() => setPasswordFocus(false)}
                        />
                        <p id="pwdnote" className={passwordFocus && !validPassword ? "instructions" : "offscreen"}>
                            <FontAwesomeIcon icon={faInfoCircle} />
                            8 to 24 characters.<br />
                            Must include uppercase and lowercase letters, a number and a special character.<br />
                            Allowed special characters: <span aria-label="exclamation mark">!</span> <span aria-label="at symbol">@</span> <span aria-label="hashtag">#</span> <span aria-label="dollar sign">$</span> <span aria-label="percent">%</span>
                        </p>


                        <label htmlFor="confirm_pwd">
                            Confirm Password:
                            <FontAwesomeIcon icon={faCheck} className={validMatchPassword && matchPassword ? "valid" : "hide"} />
                            <FontAwesomeIcon icon={faTimes} className={validMatchPassword || !matchPassword ? "hide" : "invalid"} />
                        </label>
                        <input
                            type="password"
                            id="confirm_pwd"
                            onChange={(e) => setMatchPassword(e.target.value)}
                            value={matchPassword}
                            required
                            aria-invalid={validMatchPassword ? "false" : "true"}
                            aria-describedby="confirmnote"
                            onFocus={() => setMatchPasswordFocus(true)}
                            onBlur={() => setMatchPasswordFocus(false)}
                        />
                        <p id="confirmnote" className={matchPasswordFocus && !validMatchPassword ? "instructions" : "offscreen"}>
                            <FontAwesomeIcon icon={faInfoCircle} />
                            Must match the first password input field.
                        </p>

                        <button disabled={!validUserName || !validPassword || !validMatchPassword ? true : false}>Sign Up</button>
                    </form>

                    <div className="flexGrow">
                        <Link to="/">Home</Link>
                    </div>
                </section>)}
        </>
    )
};

export default Register;
